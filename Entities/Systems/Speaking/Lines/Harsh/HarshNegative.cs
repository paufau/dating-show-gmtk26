using System.Collections.Generic;

namespace Game;

public static class HarshNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Calm,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Окей, бумер",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Окей, зумер",
                            Tags = [Tags.Calm, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Не агрись",
                            Tags = [Tags.Rich, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Скучно. Следующий!",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Лучше уже не будет",
                            Tags = [Tags.Harsh, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Дайте мне еще шанс",
                            Tags = [Tags.Calm],
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
                    Text = "Инфоцыган",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Инфоциган у тебя в штанах",
                            Tags = [Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Ну как скажешь",
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
                    Text = "Фу, симп",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Зато с машиной",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Это настоящий я",
                            Tags = [Tags.Romantic, Tags.Harsh],
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
                    Text = "Втираешь мне какую-то дичь",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Необъяснимо, но факт",
                            Tags = [Tags.Funny, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Загугли для начала",
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
                    Text = "Слабый панч, чушпан",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Сама ты чушпанка",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Прости что?",
                            Tags = [Tags.Smart, Tags.Calm],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
