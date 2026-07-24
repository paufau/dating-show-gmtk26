using Godot;

public partial class GirlVisual : Node2D
{
    [Export]
    private HeadPart.Variant UseHeadType = HeadPart.Variant.Meduim;

    [Export]
    public HeadPart? HeadPartNode;

    public override void _Ready()
    {
        HeadPartNode?.SetVariant(UseHeadType);
    }
}
