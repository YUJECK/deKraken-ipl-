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
        
        _camera = new Camera(new Vector2f(-300,-300), 2);
        _renderManager.SetCamera(_camera, 5f);
        
        _camera = new Camera(new Vector2f(300,300), 3);
        _renderManager.SetCamera(_camera, 5);
    }

    protected override void OnUpdate()
    {
        if(_inputService.IsKeyDown(Keyboard.Key.Z))
            _camera.SetCameraSize(2);
        if(_inputService.IsKeyDown(Keyboard.Key.X))
            _camera.SetCameraSize(1);
        if(_inputService.IsKeyDown(Keyboard.Key.C))
            _camera.SetCameraSize(2.73473764476f);
    }
}