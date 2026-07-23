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
    public static Dictionary<Tag, Tag> TagToPair = new()
    {
        { Tags.Rich, Tags.Romantic },
        { Tags.Romantic, Tags.Rich },
        { Tags.Calm, Tags.Harsh },
        { Tags.Harsh, Tags.Calm },
        { Tags.Smart, Tags.Funny },
        { Tags.Funny, Tags.Smart },
    };

    public static ReactionLine[] RichLines = new ReactionLine[]
    {
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
    };

    public static Dictionary<Tag, ReactionLine[]> ReactionLines = new()
    {
        { Tags.Rich, RichLines },
    };

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
