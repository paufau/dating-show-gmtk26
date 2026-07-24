using System.Collections.Generic;
using System.Linq;

namespace Game;

public class GirlData
{
    public int Simpathy = 50; // [0;100]
    public Tag[] CharacterTags = [];

    public IEnumerable<Tag> GetTagsByWeight() =>
        CharacterTags
            .GroupBy(tag => tag)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key);

    public Tag GetDominantTag() => GetTagsByWeight().First();
}
