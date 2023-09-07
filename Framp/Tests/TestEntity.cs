using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public sealed class TestEntity : Entity
{
    public override void OnCreated()
    {
        ComponentsMaster.Add(new Locality(new Vector2f(300, 300), new Vector2f(1, 1)));

        Texture texture 
            = new("D:\\GameDev\\Framp\\Framp\\Framp\\Assets\\testTexture.jpg");
        
        ComponentsMaster.Add(new SpriteRenderer(texture));
    }
}