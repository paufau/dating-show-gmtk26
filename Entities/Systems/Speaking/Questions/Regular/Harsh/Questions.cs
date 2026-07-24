namespace Game;

public static class HarshRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Ну и что в тебе такого особенного?",
            [
                new Answer("Зачитать полный список?", [Tags.Harsh, Tags.Funny]),
                new Answer("Я внимательный человек", [Tags.Calm, Tags.Romantic]),
            ]
        ),
        new Question(
            "Почему ты до сих пор один?",
            [
                new Answer("Ждал, пока ты спросишь", [Tags.Harsh, Tags.Romantic]),
                new Answer("Мама говорит, я поздний цветок", [Tags.Calm, Tags.Funny, Tags.Funny]),
            ]
        ),
    ];
}
