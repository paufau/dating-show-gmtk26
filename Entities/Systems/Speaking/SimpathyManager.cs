using System;
using System.Collections.Generic;
using System.Linq;

namespace Game;

public struct LineReactionComponent
{
    public Tag Tag;
    public int Power;
}

public class SimpathyManager
{
    private static readonly int MIN_SIMPATHY = 0;
    private static readonly int MAX_SIMPATHY = 100;

    public LineReactionComponent[] ComputeGirlReaction(GirlData girl, Tag[] tags)
    {
        var lineTags = tags ?? [];

        var components = lineTags
            .Distinct()
            .Select(tag => new LineReactionComponent
            {
                Tag = tag,
                Power = CountTag(lineTags, tag) * GetTagAffinity(girl.CharacterTags, tag),
            })
            .Where(component => component.Power != 0)
            .ToArray();

        if (
            FeatureFlags.NegativeDominantRemovesAllPositives
            && components.Length > 0
            && GetDominantComponent(components).Power < 0
        )
        {
            components = components.Where(component => component.Power < 0).ToArray();
        }

        return components;
    }

    public ReactionLine LEGACY_GetReaction(
        GirlData girl,
        LineReactionComponent[] reactionComponents,
        IReadOnlyCollection<string> textsOnCooldown
    )
    {
        var valence = reactionComponents.Sum(component => component.Power);

        if (valence > 0)
        {
            return GetValencedReaction(
                girl,
                reactionComponents.Where(component => component.Power > 0).ToArray(),
                LinesRepository.LEGACY_PositiveReactionLines,
                LinesRepository.DefaultPositiveReactions,
                textsOnCooldown
            );
        }

        if (valence < 0)
        {
            return GetValencedReaction(
                girl,
                reactionComponents.Where(component => component.Power < 0).ToArray(),
                LinesRepository.LEGACY_NegativeReactionLines,
                LinesRepository.DefaultNegativeReactions,
                textsOnCooldown
            );
        }

        return PickAvailable(LinesRepository.DefaultReactions, textsOnCooldown);
    }

    private ReactionLine GetValencedReaction(
        GirlData girl,
        LineReactionComponent[] valenceComponents,
        Dictionary<Tag, Dictionary<Tag, ReactionLine[]>> reactionLines,
        ReactionLine[] fallbackReactions,
        IReadOnlyCollection<string> textsOnCooldown
    )
    {
        if (
            valenceComponents.Length > 0
            && reactionLines.TryGetValue(girl.GetDominantTag(), out var girlReactions)
            && girlReactions.TryGetValue(
                GetDominantComponent(valenceComponents).Tag,
                out var reactions
            )
        )
        {
            var availableReactions = FilterAvailable(reactions, textsOnCooldown);

            if (availableReactions.Length > 0)
            {
                return availableReactions.PickRandom();
            }
        }

        return PickAvailable(fallbackReactions, textsOnCooldown);
    }

    private static ReactionLine PickAvailable(
        ReactionLine[] reactions,
        IReadOnlyCollection<string> textsOnCooldown
    )
    {
        var availableReactions = FilterAvailable(reactions, textsOnCooldown);
        return (availableReactions.Length > 0 ? availableReactions : reactions).PickRandom();
    }

    private static ReactionLine[] FilterAvailable(
        ReactionLine[] reactions,
        IReadOnlyCollection<string> textsOnCooldown
    ) => reactions.Where(reaction => !textsOnCooldown.Contains(reaction.Text)).ToArray();

    public LineReactionComponent GetDominantComponent(LineReactionComponent[] reactionComponents)
    {
        var maxPowerAbs = reactionComponents.Max(component => Math.Abs(component.Power));

        return reactionComponents
            .Where(component => Math.Abs(component.Power) == maxPowerAbs)
            .PickRandom();
    }

    public void UpdateSimpathy(GirlData girl, LineReactionComponent[] reactionComponents)
    {
        var simpathyChange = reactionComponents.Sum(component => component.Power);
        girl.Simpathy = Math.Clamp(girl.Simpathy + simpathyChange, MIN_SIMPATHY, MAX_SIMPATHY);
    }

    private static int GetTagAffinity(Tag[] girlTags, Tag tag)
    {
        if (LinesRepository.TryGetOppositeTag(tag, out var opposite))
        {
            return CountTag(girlTags, tag) - CountTag(girlTags, opposite);
        }

        return CountTag(girlTags, tag);
    }

    private static int CountTag(Tag[] tags, Tag tag) =>
        tags.Count(current => current.Key == tag.Key);
}
