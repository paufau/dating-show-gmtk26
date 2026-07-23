using System.Collections.Generic;

namespace Game;

public static class RichNegative
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Romantic,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Романтик нашёлся...",
                    NextLines = [],
                },
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Опять про чувства...",
                    NextLines = [],
                },
            ]
        },
    };
}
