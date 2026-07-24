using System.Collections.Generic;

namespace Game;

public static class SmartNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Funny,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Смешно. Аж забыла посмеяться",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Запомни меня таким",
                            Tags = [Tags.Funny, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Дальше лучше",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Цирк уехал, а ты остался",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Ну зачем таг грубо?",
                            Tags = [Tags.Funny, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "А теперь серьезно",
                            Tags = [Tags.Calm, Tags.Smart],
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
                    Text = "IQ, похоже, растерял?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Не найдешь, не старайся",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ага, инвестировал",
                            Tags = [Tags.Rich, Tags.Smart],
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
                    Text = "Заранее придумал?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Всю ночь придумывал",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Прочитал в одной книге",
                            Tags = [Tags.Smart, Tags.Harsh],
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
                    Text = "Следующий!",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Может не надо?",
                            Tags = [Tags.Calm, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Дальше пойдет жара, чат",
                            Tags = [Tags.Harsh, Tags.Funny],
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
                    Text = "Это не аргумент",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Да я просто угораю",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Прости, погорячился",
                            Tags = [Tags.Calm, Tags.Romantic],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
