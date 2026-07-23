using System.Collections.Generic;
using Game;
using Godot;
using Utils;

public partial class Main : Control
{
    [Export]
    public Girl[]? Girls;

    [Export]
    public PackedScene? LineOptionScene;

    [Export]
    public Node? OptionsContainer;

    private readonly List<Line> _availableLines = new();
    private readonly Dictionary<Girl, int> _reactionCooldowns = new();

    public override void _Ready()
    {
        var girls = Assert.NonNull(Girls);
        var lineOptionScene = Assert.NonNull(LineOptionScene);
        var optionsContainer = Assert.NonNull(OptionsContainer);

        ShowInitialPhrases();
    }

    private void ShowInitialPhrases()
    {
        _availableLines.Clear();
        _availableLines.AddRange(LinesRepository.InitialLines);

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

        for (var i = _availableLines.Count - 1; i >= 0; i--)
        {
            var line = _availableLines[i];

            if (line.Text == pressedLine.Text || HasAnyTag(line, excludeTags))
            {
                _availableLines.RemoveAt(i);
                continue;
            }

            line.TTL -= 1;
            if (line.TTL <= 0)
            {
                _availableLines.RemoveAt(i);
                continue;
            }

            _availableLines[i] = line;
        }
    }

    private void UpdateGirlsReactions(Line pressedLine)
    {
        var girls = Assert.NonNull(Girls);

        foreach (var girl in girls)
        {
            if (_reactionCooldowns.TryGetValue(girl, out var cooldown) && cooldown > 0)
            {
                _reactionCooldowns[girl] = cooldown - 1;
                continue;
            }

            if (!TryPickReaction(girl, pressedLine, out var reaction))
            {
                GD.PrintErr("No reactions found", pressedLine.Text);
                continue;
            }

            girl.SetSpeech(reaction.Text);
            _reactionCooldowns[girl] = reaction.Cooldown;
            AddLines(reaction.NextLines);
        }
    }

    private static bool TryPickReaction(Girl girl, Line pressedLine, out ReactionLine reaction)
    {
        reaction = default;

        foreach (var characterTag in girl.Character)
        {
            if (!HasTag(pressedLine, characterTag))
            {
                continue;
            }

            if (
                !LinesRepository.ReactionLines.TryGetValue(characterTag, out var reactions)
                || reactions.Length == 0
            )
            {
                continue;
            }

            reaction = reactions[GD.Randi() % (uint)reactions.Length];
            return true;
        }

        // TODO: react negatively when the line is from TagToPair, but maybe not needed
        return false;
    }

    private void AddLines(Line[]? lines)
    {
        if (lines == null)
        {
            return;
        }

        foreach (var line in lines)
        {
            if (_availableLines.Exists(available => available.Text == line.Text))
            {
                continue;
            }

            _availableLines.Add(line);
        }
    }

    private void RenderOptions()
    {
        var lineOptionScene = Assert.NonNull(LineOptionScene);
        var optionsContainer = Assert.NonNull(OptionsContainer);

        foreach (var child in optionsContainer.GetChildren())
        {
            optionsContainer.RemoveChild(child);
            child.QueueFree();
        }

        foreach (var line in _availableLines)
        {
            var lineOptionNode = lineOptionScene.Instantiate<LineOption>();
            lineOptionNode.Setup(line);
            lineOptionNode.OnPress += HandleLinePress;
            optionsContainer.AddChild(lineOptionNode);
        }
    }

    private static bool HasTag(Line line, Tag tag)
    {
        if (line.Tags == null)
        {
            return false;
        }

        foreach (var lineTag in line.Tags)
        {
            if (lineTag.Key == tag.Key)
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasAnyTag(Line line, Tag[] tags)
    {
        foreach (var tag in tags)
        {
            if (HasTag(line, tag))
            {
                return true;
            }
        }

        return false;
    }
}
