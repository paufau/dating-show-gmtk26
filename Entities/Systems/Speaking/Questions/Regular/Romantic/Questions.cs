namespace Game;

public static class RomanticRegular
{
    public static Question[] Questions =
    [
        new Question(
            "Ты веришь в любовь с первого взгляда?",
            [new Answer("Теперь верю", [Tags.Romantic]), new Answer("Это выдумка", [Tags.Smart])]
        ),
        new Question(
            "Опиши наше идеальное свидание",
            [
                new Answer("Танцы под дождём до утра", [Tags.Romantic]),
                new Answer("Ресторан. Плачу я", [Tags.Rich, Tags.Calm]),
            ]
        ),
    ];
}
