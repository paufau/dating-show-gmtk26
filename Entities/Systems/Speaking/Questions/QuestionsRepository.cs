using System.Collections.Generic;

namespace Game;

public static class QuestionsRepository
{
    public static Dictionary<Tag, Question[]> RegularQuestions = new()
    {
        { Tags.Rich, RichRegular.Questions },
        { Tags.Romantic, RomanticRegular.Questions },
        { Tags.Calm, CalmRegular.Questions },
        { Tags.Harsh, HarshRegular.Questions },
        { Tags.Smart, SmartRegular.Questions },
        { Tags.Funny, FunnyRegular.Questions },
    };

    public static Dictionary<Tag, Question[]> ProvocationQuestions = new();
}
