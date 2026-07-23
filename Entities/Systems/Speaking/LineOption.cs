using System;
using Game;
using Godot;

public partial class LineOption : Button
{
    public event Action<Line>? OnPress;

    private Line _Line;

    public void Setup(Line line)
    {
        _Line = line;
        Text = line.Text;
    }

    public override void _Ready()
    {
        Pressed += HandlePressed;
    }

    private void HandlePressed()
    {
        OnPress?.Invoke(_Line);
    }
}
