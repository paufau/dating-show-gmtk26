namespace Game;

public class Answer
{
    public string Text;
    public Tag[] Tags;
    public string? FlashReaction;
    public Question? FollowUp;

    public Answer(string text, Tag[] tags)
    {
        Text = text;
        Tags = tags;
    }
}

public class Question
{
    public string Text;
    public Answer[] Answers;

    public Question(string text, Answer[] answers)
    {
        Text = text;
        Answers = answers;
    }
}
