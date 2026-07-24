using System.Collections.Generic;
using Godot;
using Utils;

public partial class GlassesPart : Sprite2D
{
    public enum Variant
    {
        Nothing,
        Sun,
        Surprise,
        Freckles,
    }

    [Export]
    public Godot.Collections.Dictionary<Variant, Texture2D> TypeToTexture { get; set; } = new();

    public void SetVariant(Variant variant)
    {
        var variantTexture = Assert.NonNull(TypeToTexture.GetValueOrDefault(variant));
        Texture = variantTexture;
    }
}
