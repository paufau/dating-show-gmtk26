using System.Collections.Generic;
using System.Linq;
using Game;
using Godot;
using Utils;

public partial class GameController : Node
{
    [Export]
    public CountDownTimerSystem? CountDownTimerSystem;

    [Export]
    public PackedScene? GirlScene;

    [Export]
    public PackedScene? AnswerOptionScene;

    [Export]
    public Label? QuestionLabel;

    [Export]
    public Node? AnswersContainer;

    private readonly List<Girl> _Girls = new();
    private readonly Dictionary<Girl, HashSet<Question>> _AskedQuestions = new();
    private readonly SimpathyManager _SimpathyManager = new();

    private int _ActiveGirlIndex = 0;
    private Question? _FollowUpQuestion;

    private Girl ActiveGirl => _Girls[_ActiveGirlIndex];

    public override void _Ready()
    {
        SpawnGirls();

        var countDownTimerSystem = Assert.NonNull(CountDownTimerSystem);
        countDownTimerSystem.Start();

        StartTurn();
    }

    private void SpawnGirls()
    {
        var girlScene = Assert.NonNull(GirlScene);

        foreach (var girl in _Girls)
        {
            girl.QueueFree();
        }

        _Girls.Clear();
        _AskedQuestions.Clear();
        _ActiveGirlIndex = 0;
        _FollowUpQuestion = null;

        foreach (var girlData in new GirlsGenerator().Generate())
        {
            var girlNode = girlScene.Instantiate<Girl>();
            GD.Print(string.Join(", ", girlData.CharacterTags.Select(t => t.Key)));
            girlNode.Setup(girlData);
            _Girls.Add(girlNode);
        }
    }

    private void StartTurn()
    {
        var questionLabel = Assert.NonNull(QuestionLabel);
        var question = _FollowUpQuestion ?? PickQuestion(ActiveGirl);

        questionLabel.Text = question.Text;
        RenderAnswers(question);
    }

    private void HandleAnswerPress(Answer answer)
    {
        UpdateGirlsSimpathy(answer);

        if (answer.FlashReaction != null)
        {
            GD.Print(answer.FlashReaction);
        }

        AdvanceTurn(answer);
        StartTurn();
    }

    private void UpdateGirlsSimpathy(Answer answer)
    {
        foreach (var girl in _Girls)
        {
            var reactionComponents = _SimpathyManager.ComputeGirlReaction(girl.Data, answer.Tags);
            _SimpathyManager.UpdateSimpathy(girl.Data, reactionComponents);
        }
    }

    private void AdvanceTurn(Answer answer)
    {
        _FollowUpQuestion = answer.FollowUp;

        if (_FollowUpQuestion == null)
        {
            _ActiveGirlIndex = (_ActiveGirlIndex + 1) % _Girls.Count;
        }
    }

    private Question PickQuestion(Girl girl)
    {
        var askedQuestions = GetAskedQuestions(girl);
        var question = TryPickQuestion(girl, askedQuestions);

        if (question == null)
        {
            askedQuestions.Clear();
            question = TryPickQuestion(girl, askedQuestions);
        }

        var pickedQuestion = Assert.NonNull(question, "Girl has no questions for her tags!");
        askedQuestions.Add(pickedQuestion);
        girl.Data.AdvanceTagIndex();

        return pickedQuestion;
    }

    private static Question? TryPickQuestion(Girl girl, HashSet<Question> askedQuestions)
    {
        foreach (var tag in girl.Data.GetTagsFromCurrent())
        {
            if (!QuestionsRepository.RegularQuestions.TryGetValue(tag, out var questions))
            {
                continue;
            }

            var availableQuestions = questions
                .Where(question => !askedQuestions.Contains(question))
                .ToArray();

            if (availableQuestions.Length > 0)
            {
                return availableQuestions.PickRandom();
            }
        }

        return null;
    }

    private HashSet<Question> GetAskedQuestions(Girl girl)
    {
        if (!_AskedQuestions.TryGetValue(girl, out var askedQuestions))
        {
            askedQuestions = new HashSet<Question>();
            _AskedQuestions[girl] = askedQuestions;
        }

        return askedQuestions;
    }

    private void RenderAnswers(Question question)
    {
        var answerOptionScene = Assert.NonNull(AnswerOptionScene);
        var answersContainer = Assert.NonNull(AnswersContainer);

        ClearChildren(answersContainer);

        foreach (var answer in question.Answers)
        {
            var answerOptionNode = answerOptionScene.Instantiate<AnswerOption>();
            answerOptionNode.Setup(answer);
            answerOptionNode.OnPress += HandleAnswerPress;
            answersContainer.AddChild(answerOptionNode);
        }
    }

    private static void ClearChildren(Node container)
    {
        foreach (var child in container.GetChildren())
        {
            container.RemoveChild(child);
            child.QueueFree();
        }
    }
}
