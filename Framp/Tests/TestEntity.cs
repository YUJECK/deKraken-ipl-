using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Tests;

public sealed class TestEntity : Entity
{
    private Vector2f _currentPos;
    private float _currentPosX = 0.1f;

    public override void OnCreated()
    {
        ComponentsMaster.Add(new Locality(new Vector2f(300, 300), new Vector2f(1, 1)));

        Texture texture 
            = new(PathsHelper.Assets + "testTexture.jpg");
        
        ComponentsMaster.Add(new SpriteRenderer(texture));
    }

    public override void OnUpdate()
    {
        _currentPos.X += _currentPosX;
        _currentPos.Y += _currentPosX;

        if (_currentPos.X > 500)
        {
            _currentPos.X = 0f;
            _currentPos.Y = 0f;
        }
        
        if (_currentPos.X < 0)
        {
            _currentPos.X = 499;
            _currentPos.Y = 499;
        }

        if (InputSystem.IsKeyPressed(Keyboard.Key.Space))
            _currentPosX *= -1;
        
        ComponentsMaster.Get<Locality>().Move(_currentPos);
    }
}