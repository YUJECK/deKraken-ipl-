using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public sealed class TestEntity : Entity
{
    private Vector2f _currentPos;
    
    public override void OnCreated()
    {
        ComponentsMaster.Add(new Locality(new Vector2f(300, 300), new Vector2f(1, 1)));

        Texture texture 
            = new(PathsHelper.Assets + "testTexture.jpg");
        
        ComponentsMaster.Add(new SpriteRenderer(texture));
    }

    public override void OnUpdate()
    {
        _currentPos.X += 0.1f;
        _currentPos.Y += 0.1f;

        if (_currentPos.X >= 500)
        {
            _currentPos.X = 0f;
            _currentPos.Y = 0f;
            
            Texture texture 
                = new(PathsHelper.Assets + "testTexture.png");
            
            ComponentsMaster.Get<SpriteRenderer>().ChangeTexture(texture);
        }
        
        ComponentsMaster.Get<Locality>().Move(_currentPos);
    }
}