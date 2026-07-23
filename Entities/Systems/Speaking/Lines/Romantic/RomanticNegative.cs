using System.Collections.Generic;

namespace Game;

public static class RomanticNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Rich,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Опять деньги...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Душа в комплекте с яхтой",
                            Tags = [Tags.Rich, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Прости...",
                            Tags = [Tags.Romantic, Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Любовь не купишь!",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Всё покупается, детка",
                            Tags = [Tags.Rich, Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Поэтому дарю бесплатно",
                            Tags = [Tags.Romantic, Tags.Smart],
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
                    Text = "Где страсть? Где эмоции?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "В стихах!",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Берегу для следующего свидания",
                            Tags = [Tags.Calm, Tags.Smart],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Разбуди меня, когда влюбишься",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Просыпайся. Я уже",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ты храпишь?",
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
                    Text = "Фу, грубиян!",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Сорвалось. Мир?",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Я и не такое могу",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Я ему про чувста, а он хамит!",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я тебя понимаю",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это мой язык любви",
                            Tags = [Tags.Harsh, Tags.Funny],
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
                    Text = "Слишком умный. Аж скучно",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "От судьбы не уйдешь",
                            Tags = [Tags.Romantic, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "А мне весело, лол",
                            Tags = [Tags.Funny, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ты на свидании или на лекции?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Тема лекции — твои глаза",
                            Tags = [Tags.Romantic, Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Конспектируй, потом спрошу",
                            Tags = [Tags.Smart, Tags.Harsh],
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
                    Text = "Ты играешь с моими чувствами...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Потому что влюбился",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Смех продлевает отношения",
                            Tags = [Tags.Funny, Tags.Smart],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Клоун. А я замуж хочу",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Только после второго свидания",
                            Tags = [Tags.Romantic, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ха-ха, за клоуна?",
                            Tags = [Tags.Funny, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
