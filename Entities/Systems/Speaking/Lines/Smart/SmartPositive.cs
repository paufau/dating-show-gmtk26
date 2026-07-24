using System.Collections.Generic;

namespace Game;

public static class SmartPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Smart,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Где ты учился?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "В Оксфорде",
                            Tags = [Tags.Smart, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Даже ПТУ не закончил",
                            Tags = [Tags.Harsh, Tags.Harsh],
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
                    Text = "Инвестор, что ли?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Вложился в это свидание",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Пассивный доход, все дела",
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
                    Text = "Хм, окситоцин пошел",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Между нами химия",
                            Tags = [Tags.Romantic, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Оксимирон?",
                            Tags = [Tags.Funny, Tags.Funny, Tags.Harsh],
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
                    Text = "Дзен и логика",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я стараюсь",
                            Tags = [Tags.Calm, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Есть и еще тайны",
                            Tags = [Tags.Smart, Tags.Funny],
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
                    Text = "Редко, но метко",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Только факты",
                            Tags = [Tags.Smart, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Могу еще добавить",
                            Tags = [Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
