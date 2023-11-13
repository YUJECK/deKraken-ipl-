using Framp.DI;
using Framp.InputSystem;
using Framp.Windows;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Tests;

public sealed class PlayerEntity : Entity
{
    private Vector2f movement;
    [Inject] private InputService _inputService;
    
    public override void OnCreated()
    {
        base.OnCreated();
        
        Texture texture 
            = new(PathsHelper.Assets + "Square.png");
        
        Components.Add(new SpriteRenderer(texture));
        Components.Add(new CameraFollow());
        
        Components.Get<SpriteRenderer>().ChangeColor(Color.Blue);
    }

    public override void OnUpdate()
    {
        movement = new Vector2f(0, 0);

        if (_inputService.IsKeyPressed(Keyboard.Key.W))
            movement.Y = -0.5f;
        if (_inputService.IsKeyPressed(Keyboard.Key.S))
            movement.Y = 0.5f;
        if (_inputService.IsKeyPressed(Keyboard.Key.A))
            movement.X = -0.5f;
        if (_inputService.IsKeyPressed(Keyboard.Key.D))
            movement.X = 0.5f;
        
        Components.Get<Transform>().Move(Components.Get<Transform>().Position + movement);
    }
}