using System.Collections.Generic;
using Godot;
using Utils;

public partial class NeckPart : Sprite2D
{
    public enum Variant
    {
        Meduim,
        Dark,
        Light,
    }

    [Export]
    public Godot.Collections.Dictionary<Variant, Texture2D> TypeToTexture { get; set; } = new();

    public void SetVariant(Variant variant)
    {
        var variantTexture = Assert.NonNull(TypeToTexture.GetValueOrDefault(variant));
        Texture = variantTexture;
    }
}
