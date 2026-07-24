using System.Collections.Generic;

namespace Game;

public static class FunnyNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Smart,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Душнила",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Пик душноты впереди",
                            Tags = [Tags.Smart, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ладно-ладно, спокойно",
                            Tags = [Tags.Funny, Tags.Calm],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Слишком заумно",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "В мемы не инвестировал",
                            Tags = [Tags.Smart, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Тут тук", // todo кто там?
                            Tags = [Tags.Funny, Tags.Funny],
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
                    Text = "Купи себе чувство юмора",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "У меня целый завод",
                            Tags = [Tags.Funny, Tags.Rich],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Слишком дорого",
                            Tags = [Tags.Rich, Tags.Harsh],
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
                    Text = "Кринжанула. Это всерьез?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Абсолютно",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Пранк!",
                            Tags = [Tags.Funny, Tags.Smart],
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
                    Text = "Ты всегда такой?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Только по будням",
                            Tags = [Tags.Funny, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "А в чем дело?",
                            Tags = [Tags.Calm],
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
                    Text = "Похоже, токсик",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Чистокровный",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Сорян, вырвалось",
                            Tags = [Tags.Calm, Tags.Romantic],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
