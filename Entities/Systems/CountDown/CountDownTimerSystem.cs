using Godot;

namespace Game;

public partial class CountDownTimerSystem : Node
{
    [Export]
    public int TTL_PER_ROUND = 60;

    public bool IsActive = false;
    public float TimeLeft = 0;

    public void Start()
    {
        IsActive = true;
        TimeLeft = TTL_PER_ROUND;
    }

    public void Stop()
    {
        IsActive = false;
        TimeLeft = 0;
    }

    public override void _Process(double delta)
    {
        if (IsActive)
        {
            TimeLeft -= (float)delta;
        }

        if (TimeLeft <= 0)
        {
            Stop();
        }
    }
}
