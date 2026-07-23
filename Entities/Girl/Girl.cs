using Game;
using Godot;
using Utils;

public partial class Girl : Control
{
    [Export]
    public Label? SpeechLabel;

    public GirlData Data = new();

    public void Setup(GirlData data)
    {
        Data = data;
    }

    public void SetSpeech(string speech)
    {
        var speechLabel = Assert.NonNull(SpeechLabel);
        speechLabel.Text = speech;
    }
}
