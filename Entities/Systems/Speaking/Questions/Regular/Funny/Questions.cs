namespace Game;

public static class FunnyRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Пошути так, чтобы я запомнила",
            [
                new Answer("Я свободен сегодня вечером", [Tags.Funny, Tags.Harsh]),
                new Answer("Не в этот раз", [Tags.Smart, Tags.Calm]),
            ]
        ),
        new Question(
            "Кто твой любимый комик?",
            [
                new Answer("Это я сам", [Tags.Romantic, Tags.Calm]),
                new Answer("Джеки Чан", [Tags.Funny, Tags.Harsh]),
            ]
        ),
    ];
}
