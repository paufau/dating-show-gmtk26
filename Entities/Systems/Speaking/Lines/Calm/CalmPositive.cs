using System.Collections.Generic;

namespace Game;

public static class CalmPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Calm,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Наши чакры совпали",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Ом-м-м",
                            Tags = [Tags.Calm, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это все выдумка",
                            Tags = [Tags.Smart, Tags.Harsh],
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
                    Text = "Финансовая подушка это хорошо",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "У меня вся кровать такая",
                            Tags = [Tags.Rich, Tags.Funny, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Я в ресурсе",
                            Tags = [Tags.Rich, Tags.Calm],
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
                    Text = "Мур. Плюс вайб",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Мур-мур",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Чего?",
                            Tags = [Tags.Funny, Tags.Harsh],
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
                    Text = "Очень убедительно",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Это я умею",
                            Tags = [Tags.Smart, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Мотай себе на ус",
                            Tags = [Tags.Smart, Tags.Harsh, Tags.Harsh],
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
                    Text = "Орууу",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Продолжим после съемок?",
                            Tags = [Tags.Smart, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это лишь разминка",
                            Tags = [Tags.Funny, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
