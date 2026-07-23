namespace Game;

public static class DefaultNeutral
{
    public static ReactionLine[] Reactions =
    [
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Ага...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Ну ладно...",
            NextLines = [],
        },
        new ReactionLine()
        {
            Cooldown = Constants.FALLBACK_COOLDOWN,
            Text = "Скучно...",
            NextLines = [],
        },
    ];
}
