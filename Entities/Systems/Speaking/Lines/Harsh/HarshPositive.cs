using System.Collections.Generic;

namespace Game;

public static class HarshPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Harsh,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "База",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я шарю",
                            Tags = [Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Я не закончил",
                            Tags = [Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Rich,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Пруфы или не было",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Глянь мои сторис",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Я ходячий пруф",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Romantic,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Какой ужас... Продолжай",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Нравится такое?",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это был мой лимит",
                            Tags = [Tags.Harsh, Tags.Calm],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Smart,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ну ты сигма",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Альфа",
                            Tags = [Tags.Funny, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это кто?",
                            Tags = [Tags.Romantic, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Funny,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "А ты жесткий",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Ставьте лайки",
                            Tags = [Tags.Funny, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Эксклюзивно для вас",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
