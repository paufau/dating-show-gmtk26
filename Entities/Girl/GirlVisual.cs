using System;
using System.Linq;
using Godot;
using Utils;

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

    public override void _Ready()
    {
        Generate();
    }

    public void Generate()
    {
        // Non random rules are:
        // 1. Head and Neck are same type
        // 2. HeadTop and HeadDown are same color
        // 3. Body has a different color from HeadTop and HeadDown
        // 4. Defaults are kept for: eyes, mounth

        GenerateSkin();
        GenerateHair();
        GenerateFace();
        GenerateBody();
    }

    private void GenerateSkin()
    {
        var skinTone = Enum.GetValues<HeadPart.Variant>().PickRandom();

        Assert.NonNull(HeadPartNode).SetVariant(skinTone);
        Assert.NonNull(NeckPartNode).SetVariant(Enum.Parse<NeckPart.Variant>(skinTone.ToString()));
    }

    private void GenerateHair()
    {
        var hairColor = PickColor(HairColorPalette);

        var headTop = Assert.NonNull(HeadTopPartNode);
        headTop.SetVariant(Enum.GetValues<HeadTopPart.Variant>().PickRandom());
        headTop.SelfModulate = hairColor;

        var headDown = Assert.NonNull(HeadDownPartNode);
        headDown.SetVariant(Enum.GetValues<HeadDownPart.Variant>().PickRandom());
        headDown.SelfModulate = hairColor;
    }

    private void GenerateFace()
    {
        Assert.NonNull(NosePartNode).SetVariant(Enum.GetValues<NosePart.Variant>().PickRandom());
        Assert
            .NonNull(GlassesPartNode)
            .SetVariant(Enum.GetValues<GlassesPart.Variant>().PickRandom());
    }

    private void GenerateBody()
    {
        var hairColor = Assert.NonNull(HeadTopPartNode).SelfModulate;

        Assert.NonNull(BodyPartNode).SelfModulate = PickColor(BodyColorPalette, hairColor);
    }

    private static Color PickColor(ColorPalette? palette, params Color[] excluded)
    {
        var colors = Assert.NonNull(palette).Colors.Where(color => !excluded.Contains(color));

        Assert.That(colors.Any(), "Color palette has no colors left to pick from!");

        return colors.PickRandom();
    }
}
