using Framp.Windows;
using SFML.System;

namespace Framp.Cameras;

public sealed class BasicCameraTransition : CameraTransition
{
    private CameraTransition _cameraTransitionImplementation;

    public override async Task StartTransition(Camera currentCamera, RenderManager renderManager)
    {
        State = WorkState.Working;
        
        Vector2f startCenter = currentCamera.Center;
        float startSize = currentCamera.Size;

        Camera transitionCamera = new Camera(startCenter, startSize);
        
        currentCamera = transitionCamera;
        
        float a = startSize;   
        
        while (currentCamera.Center != ToCamera.Center)
        {
            a += 0.02f;

            if (a >= ToCamera.Size)
                a = ToCamera.Size;

            currentCamera.SetCameraSize(a);
            
            currentCamera.SetCameraPosition(
                Vector2Utilities.MoveTo(currentCamera.Center, ToCamera.Center, 4));

            renderManager.SetCamera(currentCamera);
            await Task.Delay(10);
        }
        
        renderManager.SetCamera(currentCamera);
        State = WorkState.Completed;
    }

    public override void BreakTransition()
    {
        
    }

    public BasicCameraTransition(Camera toCamera) : base(toCamera)
    {
    }
}