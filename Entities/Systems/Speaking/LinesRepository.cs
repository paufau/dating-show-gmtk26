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

    public static Dictionary<Tag, Tag> TagToPair = BuildTagToPair();

    private static Dictionary<Tag, Tag> BuildTagToPair()
    {
        var tagToPair = new Dictionary<Tag, Tag>();

        foreach (var (first, second) in TagPairs)
        {
            tagToPair[first] = second;
            tagToPair[second] = first;
        }

        return tagToPair;
    }

    public static Dictionary<Tag, ReactionLine[]> RichLines = new()
    {
        {
            Tags.Rich,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ммм, неплохо. У тебя свой бизнес?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я криптоинвестор",
                            Tags = [Tags.Rich, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Наследство от бабули",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };

    public static Dictionary<Tag, Dictionary<Tag, ReactionLine[]>> ReactionLines = new()
    {
        { Tags.Rich, RichLines },
    };

    public static ReactionLine[] DefaultReactions =
    [
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Ага...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Ну ладно...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Скучно...",
            NextLines = [],
        },
    ];

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
            Text = "Я на Тесле приехал",
            Tags = [Tags.Rich, Tags.Calm],
            ExcludeTags = [Tags.Hello],
            TTL = 3,
        },
        new Line()
        {
            Text = "Ненавижу эти шоу",
            Tags = [Tags.Harsh],
            ExcludeTags = [Tags.Hello],
            TTL = 3,
        },
    ];
}
