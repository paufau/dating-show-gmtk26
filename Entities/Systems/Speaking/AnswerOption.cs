using System;
using Game;
using Godot;

public partial class AnswerOption : Button
{
    public event Action<Answer>? OnPress;

    private Answer? _Answer;

    public void Setup(Answer answer)
    {
        _Answer = answer;
        Text = answer.Text;
    }

    public override void _Ready()
    {
        Pressed += HandlePressed;
    }

    private void HandlePressed()
    {
        if (_Answer != null)
        {
            OnPress?.Invoke(_Answer);
        }
    }
}
