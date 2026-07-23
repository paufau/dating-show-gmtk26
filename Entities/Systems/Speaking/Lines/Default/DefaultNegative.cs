namespace Game;

public static class DefaultNegative
{
    public static ReactionLine[] Reactions =
    [
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Фу...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Так себе...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Кринж...",
            NextLines = [],
        },
    ];
}
