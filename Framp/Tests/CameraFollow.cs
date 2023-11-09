using Framp.DI;
using Framp.InputSystem;
using Framp.Windows;
using SFML.System;
using SFML.Window;

namespace Framp.Tests;

public class CameraFollow : Component
{
    [Inject] private RenderManager _renderManager;
    [Inject] private InputService _inputService;
    private Camera _camera;
    
    protected override void OnStart()
    {
        _camera = new Camera(new Vector2f(0,0), 1);
        _renderManager.SetCamera(_camera);
        
        _camera = new Camera(new Vector2f(300,300), 1);
        _renderManager.SetCamera(_camera, 0.4f);
    }

    protected override void OnUpdate()
    {   
        // _camera.SetCameraPosition(Entity.Components.Get<Transform>().Position);
        //
        // if (_inputService.IsKeyDown(Keyboard.Key.C))
        // {
        //     _camera.SetCameraSize(1.1f);
        // }
        //
        // if (_inputService.IsKeyDown(Keyboard.Key.F))
        // {
        //     _camera.SetCameraSize(1.4f);
        // }
        
        _camera.SetCameraPosition(Vector2Utilities.MoveTo(_camera.Center, new Vector2f(300,300), 0.5f));
    }
}