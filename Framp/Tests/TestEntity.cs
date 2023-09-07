using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public sealed class TestEntity : Entity
{
    private Vector2f currentPos;
    
    public override void OnCreated()
    {
        ComponentsMaster.Add(new Locality(new Vector2f(300, 300), new Vector2f(1, 1)));

        Texture texture 
            = new("D:\\GameDev\\Framp\\Framp\\Framp\\Assets\\testTexture.jpg");
        
        ComponentsMaster.Add(new SpriteRenderer(texture));
    }

    public override void OnUpdate()
    {
        currentPos.X += 0.1f;
        currentPos.Y += 0.1f;

        if (currentPos.X >= 500)
        {
            currentPos.X = 0f;
            currentPos.Y = 0f;
        }
        
        ComponentsMaster.Get<Locality>().Transformable.Position = currentPos;
    }
}