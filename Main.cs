using System.Collections.Generic;
using System.Linq;
using Game;
using Godot;
using Utils;

public partial class Main : Control
{
    [Export]
    public PackedScene? LineOptionScene;

    [Export]
    public PackedScene? GirlScene;

    [Export]
    public Node? OptionsContainer;

    [Export]
    public Node? GirlsContainer;

    private readonly List<Line> _AvailableLines = new();
    private readonly List<Girl> _Girls = new();
    private readonly Dictionary<Girl, int> _ReactionCooldowns = new();
    private readonly SimpathyManager _SimpathyManager = new();

    public override void _Ready()
    {
        SpawnGirls();
        ShowInitialPhrases();
    }

    private void SpawnGirls()
    {
        var girlScene = Assert.NonNull(GirlScene);
        var girlsContainer = Assert.NonNull(GirlsContainer);

        ClearChildren(girlsContainer);
        _Girls.Clear();
        _ReactionCooldowns.Clear();

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
        _AvailableLines.Clear();
        _AvailableLines.AddRange(LinesRepository.InitialLines);

        RenderOptions();
    }

    public void HandleLinePress(Line line)
    {
        PruneLines(line);
        UpdateGirlsReactions(line);
        RenderOptions();
    }

    private void PruneLines(Line pressedLine)
    {
        var excludeTags = pressedLine.ExcludeTags ?? [];

        for (var i = _AvailableLines.Count - 1; i >= 0; i--)
        {
            var line = _AvailableLines[i];
            line.TTL -= 1;

            var isSpent =
                line.Text == pressedLine.Text || HasAnyTag(line, excludeTags) || line.TTL <= 0;

            if (isSpent)
            {
                _AvailableLines.RemoveAt(i);
                continue;
            }

            _AvailableLines[i] = line;
        }
    }

    private void UpdateGirlsReactions(Line pressedLine)
    {
        foreach (var girl in _Girls)
        {
            var reactionComponents = _SimpathyManager.ComputeGirlReaction(girl.Data, pressedLine);
            _SimpathyManager.UpdateSimpathy(girl.Data, reactionComponents);

            if (_ReactionCooldowns.TryGetValue(girl, out var cooldown) && cooldown > 0)
            {
                _ReactionCooldowns[girl] = cooldown - 1;
                continue;
            }

            var reaction = _SimpathyManager.GetReaction(girl.Data, reactionComponents);

            girl.SetSpeech(reaction.Text);
            _ReactionCooldowns[girl] = reaction.Cooldown;
            AddLines(reaction.NextLines);
        }
    }

    private void AddLines(Line[]? lines)
    {
        if (lines == null)
        {
            return;
        }

        foreach (var line in lines)
        {
            if (!_AvailableLines.Any(available => available.Text == line.Text))
            {
                _AvailableLines.Add(line);
            }
        }
    }

    private void RenderOptions()
    {
        var lineOptionScene = Assert.NonNull(LineOptionScene);
        var optionsContainer = Assert.NonNull(OptionsContainer);

        ClearChildren(optionsContainer);

        foreach (var line in _AvailableLines)
        {
            var lineOptionNode = lineOptionScene.Instantiate<LineOption>();
            lineOptionNode.Setup(line);
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
