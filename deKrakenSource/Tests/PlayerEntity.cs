using deKraken.DI;
using deKraken.Events;
using deKraken.InputSystem;
using deKraken.Windows;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Event = deKraken.Events.Event;

namespace deKraken.Tests;

public sealed class PlayerEntity : Entity
{
    [Inject] private InputService _inputService;
    [Inject] private EventManager _eventManager;
    
    private Vector2f movement;

    public override void OnCreated()
    {
        base.OnCreated();
        
        Texture texture 
            = new(PathsHelper.Assets + "Square.png");
        
        Components.Add(new SpriteRenderer(texture));
        Components.Add(new CameraFollow());
        
        Components.Get<SpriteRenderer>().ChangeColor(Color.Blue);
        
        _eventManager.SubscribeOnEvent<TestEvent>(OnTestEvent);
    }

    private void OnTestEvent(TestEvent eEvent)
    {
        Components.Get<SpriteRenderer>().ChangeColor(Color.White);
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