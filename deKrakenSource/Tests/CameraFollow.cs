using deKraken.Cameras;
using deKraken.DI;
using deKraken.Events;
using deKraken.InputSystem;
using deKraken.Windows;
using SFML.System;
using SFML.Window;

namespace deKraken.Tests;

public class CameraFollow : Component
{
    [Inject] private RenderManager _renderManager;
    [Inject] private InputService _inputService;
    [Inject] private EventManager _eventManager;
    
    private Camera _camera;
    
    protected override void OnStart()
    {
        _camera = new Camera(new Vector2f(0,0), 1);
        _renderManager.SetCamera(_camera);
    }

    protected override void OnUpdate()
    {
        if (_inputService.IsKeyDown(Keyboard.Key.Z))
        {
            _eventManager.PushEvent(new TestEvent());
        }
        
        if (_inputService.IsKeyDown(Keyboard.Key.X))
        {
            _camera = new Camera(new Vector2f(300,300), 1.5f);
            _renderManager.PushTransition(new BasicCameraTransition(_camera));
        }
        
        if(_inputService.IsKeyDown(Keyboard.Key.C))
        {
            _camera = new Camera(new Vector2f(0,0), 1.5f);
            _renderManager.PushTransition(new BasicCameraTransition(_camera));
        }
    }
}