namespace Game;

public static class RichRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Кем ты работаешь?",
            [
                new Answer("У меня свой бизнес", [Tags.Rich, Tags.Calm]),
                new Answer("Я коллекционирую воспоминания", [Tags.Romantic, Tags.Funny]),
            ]
        ),
        new Question(
            "Какая у тебя машина?",
            [
                new Answer("Их у меня три", [Tags.Rich, Tags.Harsh]),
                new Answer("Разве это важно?", [Tags.Harsh, Tags.Smart]),
            ]
        ),
    ];
}
