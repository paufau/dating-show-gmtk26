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
        return Enumerable
            .Range(0, GIRLS_COUNT)
            .Select(_ => new GirlData { CharacterTags = GenerateTags() });
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

            if (LinesRepository.TagToPair.TryGetValue(tag, out var opposite))
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

            if (LinesRepository.TagToPair.TryGetValue(freeTag, out var opposite))
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
        LinesRepository.TagToPair.TryGetValue(tag, out var opposite) && tags.Contains(opposite);
}
