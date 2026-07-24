using System.Collections.Generic;
using System.Linq;

namespace Game;

public class GirlData
{
    public int Simpathy = 50; // [0;100]
    public Tag[] CharacterTags = [];

    public int LastAskedTagIndex = 0;

    public void AdvanceTagIndex()
    {
        if (CharacterTags.Length == 0)
        {
            return;
        }

        LastAskedTagIndex = (LastAskedTagIndex + 1) % CharacterTags.Length;
    }

    public Tag GetQuestionTag() => CharacterTags[LastAskedTagIndex % CharacterTags.Length];

    public IEnumerable<Tag> GetTagsFromCurrent() =>
        Enumerable
            .Range(0, CharacterTags.Length)
            .Select(offset => CharacterTags[(LastAskedTagIndex + offset) % CharacterTags.Length]);

    public IEnumerable<Tag> GetTagsByWeight() =>
        CharacterTags
            .GroupBy(tag => tag)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key);

    public Tag GetDominantTag() => GetTagsByWeight().First();
}
