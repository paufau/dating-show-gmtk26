namespace Game;

public static class DefaultPositive
{
    public static ReactionLine[] Reactions =
    [
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Хах, забавно",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Продолжай...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Интересно",
            NextLines = [],
        },
    ];
}
