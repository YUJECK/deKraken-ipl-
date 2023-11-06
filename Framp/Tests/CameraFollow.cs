using Framp.DI;
using Framp.Windows;
using SFML.System;

namespace Framp.Tests;

public class CameraFollow : Component
{
    [Inject] private RenderManager _renderManager;
    private Camera _camera;
    
    protected override void OnStart()
    {
        _camera = new Camera();
        _renderManager.SetCamera(_camera);
    }

    protected override void OnUpdate()
    {
        _camera.SetCameraPosition(Entity.Components.Get<Transform>().Position);
    }
}