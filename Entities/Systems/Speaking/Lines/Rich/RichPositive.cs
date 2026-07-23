using System.Collections.Generic;

namespace Game;

public static class RichPositive
{
    public static Dictionary<Tag, ReactionLine[]> Lines = new()
    {
        {
            Tags.Rich,
            [
                new ReactionLine()
                {
                    Cooldown = Constants.DEFAULT_COOLDOWN,
                    Text = "Ммм, неплохо. У тебя свой бизнес?",
                    NextLines =
                    [
                        new Line()
                        {
                            Text = "Я криптоинвестор",
                            Tags = [Tags.Rich, Tags.Smart],
                            TTL = 1,
                        },
                        new Line()
                        {
                            Text = "Наследство от бабули",
                            Tags = [Tags.Romantic, Tags.Funny],
                            TTL = 1,
                        },
                    ],
                },
            ]
        },
    };
}
