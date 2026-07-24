namespace Game;

public static class CalmRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Как проходит твоё идеальное воскресенье?",
            [
                new Answer("Сплю. Потом ещё сплю", [Tags.Calm, Tags.Funny]),
                new Answer("Воскресенье? Не слышал", [Tags.Harsh, Tags.Rich]),
            ]
        ),
        new Question(
            "Ты умеешь просто слушать?",
            [
                new Answer("Я весь во внимании", [Tags.Calm, Tags.Romantic]),
                new Answer("Больше люблю говорить", [Tags.Harsh, Tags.Funny]),
            ]
        ),
    ];
}
