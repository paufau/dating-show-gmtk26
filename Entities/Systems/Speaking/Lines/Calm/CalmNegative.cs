using System.Collections.Generic;

namespace Game;

public static class CalmNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Harsh,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Минус вайб",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "На чиле, на расслабоне",
                            Tags = [Tags.Calm, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Плак-плак",
                            Tags = [Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Меня от тебя трясет",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Дыши глубже",
                            Tags = [Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это вибрации любви",
                            Tags = [Tags.Romantic, Tags.Funny],
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
                    Text = "Успешный успех...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Чего ты желаешь?",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Деньги — пыль",
                            Tags = [Tags.Calm, Tags.Smart],
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
                    Text = "Так, это лавбомбинг",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Это салют",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Проработаю с психологом",
                            Tags = [Tags.Calm, Tags.Harsh],
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
                    Text = "Душно. Откройте окно",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Сама душная",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это ветер знаний",
                            Tags = [Tags.Smart],
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
                    Text = "Ха. Ха. Ха",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "А по-моему забавно",
                            Tags = [Tags.Funny, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это черный юмор, извини",
                            Tags = [Tags.Smart, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
