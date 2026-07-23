using System.Collections.Generic;

namespace Game;

public static class RomanticPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Romantic,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ах, у меня аж мурашки...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Вместе мы расцветем",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Нужен сеанс массажа?",
                            Tags = [Tags.Rich, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Мы что в фильме про любовь?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Ты для меня в главной роли",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "И снято Гаем Ричи",
                            Tags = [Tags.Harsh, Tags.Funny, Tags.Harsh, Tags.Funny],
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
                    Text = "С тобой так спокойно...",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Всегда так будет",
                            Tags = [Tags.Calm, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Не привыкай, крастока",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ты напоминаешь как мамин борщ",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Такой же горячий?",
                            Tags = [Tags.Funny, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Такой же холодный?",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Funny],
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
                    Text = "Грубоват... но сердце доброе",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Только для тебя",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "У меня только прессуха!",
                            Tags = [Tags.Harsh, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Люблю плохих парней",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я неисправим",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "А потянешь?",
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
                    Text = "Умный и чувственный? Так бывает?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я из лимитированной серии",
                            Tags = [Tags.Smart, Tags.Funny],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Поверь мне, да",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Расскажешь мне про звёзды?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "И про твои глаза",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Типо Брэд Питт?",
                            Tags = [Tags.Harsh, Tags.Funny, Tags.Funny],
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
                    Text = "Хи-хи! С тобой не соскучишься",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "У меня потрясная аудитория",
                            Tags = [Tags.Romantic, Tags.Calm],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "А я вот заскучал",
                            Tags = [Tags.Harsh, Tags.Harsh, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ты такой милашка",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Это судьба",
                            Tags = [Tags.Romantic, Tags.Romantic],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Но не во всех местах",
                            Tags = [Tags.Funny, Tags.Harsh],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
