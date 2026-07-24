using System.Collections.Generic;
using System.Linq;

namespace Game;

public class GirlsGenerator
{
    private static readonly int GIRLS_COUNT = 3;
    private static readonly int TAGS_PER_GIRL = 7;
    private static readonly int UNIQ_TAGS_PER_GIRL = 3;

    public IEnumerable<GirlData> Generate()
    {
        var girls = Enumerable
            .Range(0, GIRLS_COUNT)
            .Select(_ => new GirlData { CharacterTags = GenerateTags() })
            .ToArray();

        if (FeatureFlags.MainAndBestieGenerationFeature)
        {
            SpreadMainTag(girls);
        }

        return girls;
    }

    private static void SpreadMainTag(GirlData[] girls)
    {
        var mainTag = girls[0].GetDominantTag();

        PromoteToSecond(girls[1].CharacterTags, mainTag);

        foreach (var girl in girls.Skip(2))
        {
            RemoveMainTag(girl.CharacterTags, mainTag);
        }
    }

    private static void PromoteToSecond(Tag[] tags, Tag mainTag)
    {
        var counts = tags.GroupBy(tag => tag)
            .ToDictionary(group => group.Key, group => group.Count());
        var secondCount = counts.Values.Distinct().OrderByDescending(count => count).ElementAt(1);

        if (counts.GetValueOrDefault(mainTag) == secondCount)
        {
            return;
        }

        var replacedTag = counts
            .Keys.Where(tag => counts[tag] == secondCount && !tag.Equals(mainTag))
            .PickRandom();

        SwapTags(tags, replacedTag, mainTag);

        if (
            !counts.ContainsKey(mainTag)
            && LinesRepository.TryGetOppositeTag(mainTag, out var oppositeTag)
            && counts.ContainsKey(oppositeTag)
            && !oppositeTag.Equals(replacedTag)
        )
        {
            SwapTags(tags, oppositeTag, replacedTag);
        }
    }

    private static void RemoveMainTag(Tag[] tags, Tag mainTag)
    {
        if (!tags.Contains(mainTag))
        {
            return;
        }

        var keptTags = tags.Where(tag => !tag.Equals(mainTag)).ToList();

        var replacementTag = LinesRepository
            .CommonTags.Where(tag =>
                !tag.Equals(mainTag) && !keptTags.Contains(tag) && !IsOppositeOfAny(tag, keptTags)
            )
            .PickRandom();

        SwapTags(tags, mainTag, replacementTag);
    }

    private static void SwapTags(Tag[] tags, Tag from, Tag to)
    {
        for (var i = 0; i < tags.Length; i++)
        {
            if (tags[i].Equals(from))
            {
                tags[i] = to;
            }
            else if (tags[i].Equals(to))
            {
                tags[i] = from;
            }
        }
    }

    private static Tag[] GenerateTags()
    {
        var tags = GetRandomTagsList();
        RepairGroups(tags);
        return tags.ToArray();
    }

    private static List<Tag> GetRandomTagsList()
    {
        var availableTags = LinesRepository.CommonTags.ToList();
        var tags = new List<Tag>();

        while (tags.Count < TAGS_PER_GIRL && availableTags.Count > 0)
        {
            var tag = availableTags.PickRandom();
            tags.Add(tag);

            if (LinesRepository.TryGetOppositeTag(tag, out var opposite))
            {
                availableTags.Remove(opposite);
            }
        }

        return tags;
    }

    private static void RepairGroups(List<Tag> tags)
    {
        var missing = UNIQ_TAGS_PER_GIRL - CountGroups(tags);

        var freeTags = LinesRepository
            .CommonTags.Where(tag => !tags.Contains(tag) && !IsOppositeOfAny(tag, tags))
            .ToList();

        for (var iMissing = 0; iMissing < missing && freeTags.Count > 0; iMissing++)
        {
            if (!TryFreeSlot(tags))
            {
                return;
            }

            var freeTag = freeTags.PickRandom();
            tags.Add(freeTag);

            freeTags.Remove(freeTag);

            if (LinesRepository.TryGetOppositeTag(freeTag, out var opposite))
            {
                freeTags.Remove(opposite);
            }
        }
    }

    private static bool TryFreeSlot(List<Tag> tags)
    {
        var spareTags = tags.GroupBy(tag => tag)
            .Where(group => group.Count() > 1)
            .OrderBy(group => group.Count())
            .Select(group => group.Key)
            .ToList();

        if (spareTags.Count == 0)
        {
            return false;
        }

        tags.Remove(spareTags[0]);
        return true;
    }

    private static int CountGroups(List<Tag> tags) => tags.Distinct().Count();

    private static bool IsOppositeOfAny(Tag tag, List<Tag> tags) =>
        LinesRepository.TryGetOppositeTag(tag, out var opposite) && tags.Contains(opposite);
}
