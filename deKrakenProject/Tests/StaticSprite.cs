using SFML.Graphics;
using SFML.System;

namespace deKraken.Tests;

public class StaticSprite : Entity
{
    public override void OnCreated()
    {
        base.OnCreated();
        
        Transform.Move(new Vector2f(100, 100)); 
        Transform.ScaleIt(new Vector2f(1000,1000));
        
        Components.Add(new SpriteRenderer(new Texture(PathsHelper.Assets + "Square.png")));
    }
} 