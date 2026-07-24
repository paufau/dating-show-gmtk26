using System.Collections.Generic;
using System.Linq;
using Game;
using Godot;
using Utils;

public partial class Main : Node
{
    [Export]
    public CountDownTimerSystem? CountDownTimerSystem;

    [Export]
    public PackedScene? LineOptionScene;

    [Export]
    public PackedScene? GirlScene;

    [Export]
    public Node? OptionsContainer;

    [Export]
    public Node? GirlsContainer;

    private readonly List<ActiveLine> _ActiveLines = new();
    private readonly List<Girl> _Girls = new();
    private readonly Dictionary<Girl, Dictionary<string, int>> _ReactionCooldowns = new();
    private readonly SimpathyManager _SimpathyManager = new();

    public override void _Ready()
    {
        SpawnGirls();
        ShowInitialPhrases();

        var countDownTimerSystem = Assert.NonNull(CountDownTimerSystem);
        countDownTimerSystem.Start();
    }

    private void SpawnGirls()
    {
        var girlScene = Assert.NonNull(GirlScene);
        var girlsContainer = Assert.NonNull(GirlsContainer);

        ClearChildren(girlsContainer);
        _Girls.Clear();
        _ReactionCooldowns.Clear();
        _ActiveLines.Clear();

        foreach (var girlData in new GirlsGenerator().Generate())
        {
            var girlNode = girlScene.Instantiate<Girl>();
            GD.Print(string.Join(", ", girlData.CharacterTags.Select(t => t.Key)));
            girlNode.Setup(girlData);
            girlsContainer.AddChild(girlNode);
            _Girls.Add(girlNode);
        }
    }

    private void ShowInitialPhrases()
    {
        _ActiveLines.Clear();
        AddLines(LinesRepository.InitialLines);

        RenderOptions();
    }

    public void HandleLinePress(Line line)
    {
        PruneLines(line);
        UpdateGirlsReactions(line);
        RefillLinesIfEmpty(line);
        RenderOptions();
    }

    private void PruneLines(Line pressedLine)
    {
        var excludeTags = pressedLine.ExcludeTags ?? [];

        for (var i = _ActiveLines.Count - 1; i >= 0; i--)
        {
            var activeLine = _ActiveLines[i];
            activeLine.Line.TTL -= 1;

            var isSpent =
                activeLine.Line.Text == pressedLine.Text
                || HasAnyTag(activeLine.Line, excludeTags)
                || activeLine.Line.TTL <= 0;

            if (isSpent)
            {
                _ActiveLines.RemoveAt(i);
            }
        }
    }

    private void UpdateGirlsReactions(Line pressedLine)
    {
        foreach (var girl in _Girls)
        {
            var reactionComponents = _SimpathyManager.ComputeGirlReaction(girl.Data, pressedLine);
            _SimpathyManager.UpdateSimpathy(girl.Data, reactionComponents);

            var cooldowns = GetReactionCooldowns(girl);
            var reaction = _SimpathyManager.GetReaction(
                girl.Data,
                reactionComponents,
                cooldowns.Keys.ToHashSet()
            );

            TickCooldowns(cooldowns);
            cooldowns[reaction.Text] = reaction.Cooldown;

            girl.SetSpeech(reaction.Text);
            AddLines(reaction.NextLines, girl);
        }
    }

    private Dictionary<string, int> GetReactionCooldowns(Girl girl)
    {
        if (!_ReactionCooldowns.TryGetValue(girl, out var cooldowns))
        {
            cooldowns = new Dictionary<string, int>();
            _ReactionCooldowns[girl] = cooldowns;
        }

        return cooldowns;
    }

    private static void TickCooldowns(Dictionary<string, int> cooldowns)
    {
        foreach (var (text, turnsLeft) in cooldowns.ToArray())
        {
            if (turnsLeft <= 1)
            {
                cooldowns.Remove(text);
            }
            else
            {
                cooldowns[text] = turnsLeft - 1;
            }
        }
    }

    private void RefillLinesIfEmpty(Line pressedLine)
    {
        if (_ActiveLines.Count > 0)
        {
            return;
        }

        // TODO this is a temporary thing, makes sense to introduce meaningfull lines
        var fallbackLines = LinesRepository
            .InitialLines.Where(line => !HasTag(line, Tags.Hello) && line.Text != pressedLine.Text)
            .ToArray();

        AddLines(fallbackLines);
    }

    private void AddLines(Line[]? lines, Girl? source = null)
    {
        if (lines == null)
        {
            return;
        }

        foreach (var line in lines)
        {
            var activeLine = _ActiveLines.FirstOrDefault(active => active.Line.Text == line.Text);

            if (activeLine == null)
            {
                activeLine = new ActiveLine { Line = line };
                _ActiveLines.Add(activeLine);
            }

            if (source != null && !activeLine.Sources.Contains(source))
            {
                activeLine.Sources.Add(source);
            }
        }
    }

    private void RenderOptions()
    {
        var lineOptionScene = Assert.NonNull(LineOptionScene);
        var optionsContainer = Assert.NonNull(OptionsContainer);

        ClearChildren(optionsContainer);

        foreach (var activeLine in _ActiveLines)
        {
            var lineOptionNode = lineOptionScene.Instantiate<LineOption>();
            lineOptionNode.Setup(activeLine.Line);
            lineOptionNode.OnPress += HandleLinePress;
            optionsContainer.AddChild(lineOptionNode);
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

    private static bool HasTag(Line line, Tag tag) =>
        line.Tags?.Any(lineTag => lineTag.Key == tag.Key) ?? false;

    private static bool HasAnyTag(Line line, Tag[] tags) => tags.Any(tag => HasTag(line, tag));
}
