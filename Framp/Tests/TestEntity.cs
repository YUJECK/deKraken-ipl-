using Framp.DI;
using Framp.InputSystem;
using Framp.Windows;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Tests;

public sealed class TestEntity : Entity
{
    private Vector2f _currentPos;
    private float _currentPosX = 0.1f;
    [Inject] private InputService _inputService;
    
    private void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    
    public override void OnCreated()
    {
        ComponentsMaster.Add(new Transform(new Vector2f(0, 0), new Vector2f(1, 1)));

        Texture texture 
            = new(PathsHelper.Assets + "Square.png");
        
        ComponentsMaster.Add(new SpriteRenderer(texture));
    }

    public override void OnUpdate()
    {
        _currentPos.X += _currentPosX;
        _currentPos.Y += _currentPosX;

        if (_currentPos.X > 200 || _currentPos.Y > 200)
        {
            _currentPos.X = 0f;
            _currentPos.Y = 0f;
        }
        
        if (_currentPos.X < 0)
        {
            _currentPos.X = 200;
            _currentPos.Y = 200;
        }

        if (_inputService.IsKeyUp(Keyboard.Key.Space))
            _currentPosX *= -1;
        
        ComponentsMaster.Get<Transform>().Move(_currentPos);
    }
}