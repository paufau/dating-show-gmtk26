using System.Collections.Generic;

namespace Game;

public static class RichPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
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
        {
            Tags.Calm,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Знаешь, я ищу надежного",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Как швейчарский банк?",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Взломай — узнаешь",
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
                    Text = "Люблю дерзких",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Покатать на БМВ?",
                            Tags = [Tags.Rich, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Сначала свидание",
                            Tags = [Tags.Romantic, Tags.Romantic],
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
                    Text = "Учился в Оксфорде?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Вложил все в интеллект",
                            Tags = [Tags.Smart, Tags.Rich],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Поумнее твоих бывших, да?",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Funny],
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
                    Text = "Смешной. Будешь моим Нетфликсом?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Только по вечерам",
                            Tags = [Tags.Funny, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Юмор бесплатный, остальное - нет",
                            Tags = [Tags.Funny, Tags.Funny, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
