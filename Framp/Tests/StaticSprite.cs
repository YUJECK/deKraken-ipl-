using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public class StaticSprite : Entity
{
    public override void OnCreated()
    {
        ComponentsMaster.Add(new Transform(new Vector2f(100, 100), new Vector2f(1,1)));
        ComponentsMaster.Add(new SpriteRenderer(new Texture(PathsHelper.Assets + "Square.png")));
    }
}