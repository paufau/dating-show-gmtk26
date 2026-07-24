using System.Collections.Generic;

namespace Game;

public static class FunnyPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Funny,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ха-ха-ха. Легендарно",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "У меня такого навалом",
                            Tags = [Tags.Funny, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Спасибо за донаты, чат",
                            Tags = [Tags.Rich, Tags.Funny],
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
                    Text = "Люблю шутки про деньги. И деньги",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Это ж не шутка",
                            Tags = [Tags.Rich, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Могу познакомить",
                            Tags = [Tags.Funny, Tags.Rich],
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
                    Text = "Мимими. Щас растаю",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Растай в моих объятиях",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Только не на камеру",
                            Tags = [Tags.Funny, Tags.Calm],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Calm,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Буду тебя бесить",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Попробуй",
                            Tags = [Tags.Harsh, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "У меня иммунитет",
                            Tags = [Tags.Calm, Tags.Smart],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
        {
            Tags.Harsh,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Пхах, вот это ты выдал",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Хах, спасибо",
                            Tags = [Tags.Smart, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Не повторяй дома",
                            Tags = [Tags.Smart, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
