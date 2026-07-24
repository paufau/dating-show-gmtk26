using System;
using Game;
using Godot;
using Utils;

public partial class RoundDurationController : Node
{
    [Export]
    public CountDownTimerSystem? System;

    [Export]
    public ProgressBar? Progress;

    public override void _Process(double delta)
    {
        var progress = Assert.NonNull(Progress);
        var system = Assert.NonNull(System);

        progress.Value = system.TimeLeft / system.TTL_PER_ROUND * 100;
    }
}
