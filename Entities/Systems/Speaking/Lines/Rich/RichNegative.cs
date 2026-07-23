using System.Collections.Generic;

namespace Game;

public static class RichNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Romantic,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Романтик нашёлся...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Могу себе позволить",
                            Tags = [Tags.Rich, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Сердце не купишь",
                            Tags = [Tags.Romantic, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Опять про чувства...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Да у меня миллион чувств",
                            Tags = [Tags.Rich, Tags.Rich],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ты тоже как-нибудь попробуй",
                            Tags = [Tags.Romantic, Tags.Harsh],
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
                    Text = "Скучный, как вклад под пол процента",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Зато с гарантией, детка",
                            Tags = [Tags.Calm, Tags.Rich],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Как твой бывший?",
                            Tags = [Tags.Harsh, Tags.Harsh],
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
                    Text = "Агришься? Значит, бомж",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я уеду отсюда на БМВ",
                            Tags = [Tags.Harsh, Tags.Rich],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Пффф... Нервы дороже",
                            Tags = [Tags.Calm, Tags.Smart],
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
                    Text = "Скажи еще что-нибудь на ботанском",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Оффшоры, Пентхаус, Италия",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Мой IQ выше твоих каблуков",
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
                    Text = "Клоунов не спонсирую",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "... сказала она",
                            Tags = [Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это был тест. Ты его провалила",
                            Tags = [Tags.Rich, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
