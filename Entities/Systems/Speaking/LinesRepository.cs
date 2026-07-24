using System.Collections.Generic;

namespace Game;

public struct Tag
{
    public string Key;
}

public struct Line
{
    public string Text;
    public Tag[] Tags;
    public Tag[] ExcludeTags;
    public int TTL;
}

public struct ReactionLine
{
    public string Text;
    public Line[] NextLines;
    public int Cooldown;
}

public static class Constants
{
    public static int DEFAULT_COOLDOWN = 5;
    public static int FALLBACK_COOLDOWN = 1;
}

public static class Tags
{
    // Characteristic pairs
    public static Tag Rich = new Tag { Key = "rich" };
    public static Tag Romantic = new Tag { Key = "romantic" };
    public static Tag Calm = new Tag { Key = "calm" };
    public static Tag Harsh = new Tag { Key = "harsh" };
    public static Tag Smart = new Tag { Key = "smart" };
    public static Tag Funny = new Tag { Key = "funny" };

    // Service
    public static Tag Hello = new Tag { Key = "hello" };
}

public class LinesRepository
{
    public static Tag[] CommonTags =
    [
        Tags.Rich,
        Tags.Romantic,
        Tags.Calm,
        Tags.Harsh,
        Tags.Smart,
        Tags.Funny,
    ];

    // Opposite characteristics. A girl only ever takes one side of a pair.
    public static (Tag First, Tag Second)[] TagPairs =
    [
        (Tags.Rich, Tags.Romantic),
        (Tags.Calm, Tags.Harsh),
        (Tags.Smart, Tags.Funny),
    ];

    public static bool TryGetOppositeTag(Tag tag, out Tag opposite)
    {
        foreach (var (first, second) in TagPairs)
        {
            if (first.Key == tag.Key)
            {
                opposite = second;
                return true;
            }

            if (second.Key == tag.Key)
            {
                opposite = first;
                return true;
            }
        }

        opposite = default;
        return false;
    }

    public static Dictionary<Tag, Dictionary<Tag, ReactionLine[]>> PositiveReactionLines = new()
    {
        { Tags.Rich, RichPositive.Lines },
        { Tags.Romantic, RomanticPositive.Lines },
        { Tags.Calm, CalmPositive.Lines },
        { Tags.Harsh, HarshPositive.Lines },
        { Tags.Smart, SmartPositive.Lines },
        { Tags.Funny, FunnyPositive.Lines },
    };

    public static Dictionary<Tag, Dictionary<Tag, ReactionLine[]>> NegativeReactionLines = new()
    {
        { Tags.Rich, RichNegative.Lines },
        { Tags.Romantic, RomanticNegative.Lines },
        { Tags.Calm, CalmNegative.Lines },
        { Tags.Harsh, HarshNegative.Lines },
        { Tags.Smart, SmartNegative.Lines },
        { Tags.Funny, FunnyNegative.Lines },
    };

    public static ReactionLine[] DefaultPositiveReactions = DefaultPositive.Reactions;
    public static ReactionLine[] DefaultNegativeReactions = DefaultNegative.Reactions;
    public static ReactionLine[] DefaultReactions = DefaultNeutral.Reactions;

    public static Line[] InitialLines =
    [
        new Line()
        {
            Text = "Привет, красотки",
            Tags = [Tags.Funny, Tags.Harsh, Tags.Hello],
            ExcludeTags = [Tags.Hello],
            TTL = 1,
        },
        new Line()
        {
            Text = "Я на BMW приехал",
            Tags = [Tags.Rich, Tags.Calm],
            ExcludeTags = [Tags.Hello],
            TTL = 1,
        },
        new Line()
        {
            Text = "Ненавижу эти шоу",
            Tags = [Tags.Harsh],
            ExcludeTags = [Tags.Hello],
            TTL = 1,
        },
    ];
}
