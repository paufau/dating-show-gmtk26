using Godot;

public partial class GirlVisual : Node2D
{
    [Export]
    public ColorPalette? BodyColorPalette;

    [Export]
    public ColorPalette? HairColorPalette;

    [Export]
    public BodyPart? BodyPartNode;

    [Export]
    public NeckPart? NeckPartNode;

    [Export]
    public HeadDownPart? HeadDownPartNode;

    [Export]
    public HeadPart? HeadPartNode;

    [Export]
    public EyesPart? EyesPartNode;

    [Export]
    public HeadTopPart? HeadTopPartNode;

    [Export]
    public NosePart? NosePartNode;

    [Export]
    public MounthPart? MounthPartNode;

    [Export]
    public GlassesPart? GlassesPartNode;

    public override void _Ready() { }

    public void Generate()
    {
        // Non random rules are:
        // 1. Head and Neck are same type
        // 2. HeadTop and HeadDown are same color
        // 3. Body has a different color from HeadTop and HeadDown
        // 4. Defaults are kept for: eyes, mounth
    }
}
