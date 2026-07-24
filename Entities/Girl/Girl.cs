using Game;
using Godot;
using Utils;

public partial class Girl : Control
{
    [Export]
    public Label? SpeechLabel;

    [Export]
    public ProgressBar? SimpathyBar;

    public GirlData Data = new();

    public void Setup(GirlData data)
    {
        Data = data;
    }

    public void LEGACY_SetSpeech(string speech)
    {
        var speechLabel = Assert.NonNull(SpeechLabel);
        speechLabel.Text = speech;
    }

    public override void _Process(double delta)
    {
        var simpathyBar = Assert.NonNull(SimpathyBar);
        simpathyBar.Value = Data.Simpathy;
    }
}
