using System;
using Game;
using Godot;
using Utils;

public partial class Girl : Control
{
    [Export]
    public Label? SpeechLabel;

    public Tag[] Character = [Tags.Rich];

    public void SetSpeech(string speech)
    {
        var speechLabel = Assert.NonNull(SpeechLabel);
        speechLabel.Text = speech;
    }
}
