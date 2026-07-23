using System;
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

    public LineReactionComponent[] ComputeGirlReaction(GirlData girl, Line line)
    {
        var lineTags = line.Tags ?? [];

        return lineTags
            .Distinct()
            .Select(tag => new LineReactionComponent
            {
                Tag = tag,
                Power = CountTag(lineTags, tag) * GetTagAffinity(girl.CharacterTags, tag),
            })
            .Where(component => component.Power != 0)
            .ToArray();
    }

    public ReactionLine GetReaction(GirlData girl, LineReactionComponent[] reactionComponents)
    {
        var likedComponents = reactionComponents.Where(component => component.Power > 0).ToArray();

        if (
            likedComponents.Length > 0
            && LinesRepository.ReactionLines.TryGetValue(
                GetDominantTag(girl),
                out var girlReactions
            )
            && girlReactions.TryGetValue(
                GetDominantComponent(likedComponents).Tag,
                out var reactions
            )
            && reactions.Length > 0
        )
        {
            return reactions.PickRandom();
        }

        return LinesRepository.DefaultReactions.PickRandom();
    }

    public LineReactionComponent GetDominantComponent(LineReactionComponent[] reactionComponents)
    {
        var maxPower = reactionComponents.Max(component => component.Power);
        return reactionComponents.Where(component => component.Power == maxPower).PickRandom();
    }

    public void UpdateSimpathy(GirlData girl, LineReactionComponent[] reactionComponents)
    {
        var simpathyChange = reactionComponents.Sum(component => component.Power);
        girl.Simpathy = Math.Clamp(girl.Simpathy + simpathyChange, MIN_SIMPATHY, MAX_SIMPATHY);
    }

    private static Tag GetDominantTag(GirlData girl) =>
        girl
            .CharacterTags.GroupBy(tag => tag)
            .OrderByDescending(group => group.Count())
            .First()
            .Key;

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
