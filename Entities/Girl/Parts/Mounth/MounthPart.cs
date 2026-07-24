using System.Collections.Generic;
using Godot;
using Utils;

public partial class MounthPart : Sprite2D
{
    public enum Variant
    {
        BigSmile,
        Grumpy,
        Ooo,
        Smile,
        Flat,
    }

    [Export]
    public Godot.Collections.Dictionary<Variant, Texture2D> TypeToTexture { get; set; } = new();

    public void SetVariant(Variant variant)
    {
        var variantTexture = Assert.NonNull(TypeToTexture.GetValueOrDefault(variant));
        Texture = variantTexture;
    }
}
