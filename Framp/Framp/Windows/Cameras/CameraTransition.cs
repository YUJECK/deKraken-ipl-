using Framp.Windows;

namespace Framp.Cameras;

public abstract class CameraTransition
{
    public WorkState State { get; protected set; }
    public Camera ToCamera { get; protected set; }

    protected CameraTransition(Camera toCamera)
    {
        ToCamera = toCamera;
    }

    public abstract Task StartTransition(Camera currentCamera, RenderManager renderManager);
    public abstract void BreakTransition();
}