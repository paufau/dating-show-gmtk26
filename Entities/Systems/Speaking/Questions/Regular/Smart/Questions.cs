namespace Game;

public static class SmartRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Какую книгу ты прочитал последней?",
            [
                new Answer("Достоевского", [Tags.Smart, Tags.Calm]),
                new Answer("Меню в шаурмечной", [Tags.Funny, Tags.Harsh]),
            ]
        ),
        new Question(
            "Cтолица Австралии?",
            [
                new Answer("Канберра", [Tags.Smart, Tags.Smart])
                {
                    FollowUp = new Question(
                        "Все думают, что Сидней",
                        [
                            new Answer("Заблуждаются", [Tags.Calm]),
                            new Answer("Они дураки", [Tags.Harsh]),
                        ]
                    ),
                },
                new Answer("Кенгуру", [Tags.Funny, Tags.Funny]),
            ]
        ),
    ];
}
