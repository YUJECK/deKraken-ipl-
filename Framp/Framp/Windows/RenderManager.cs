using Framp.InputSystem;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Windows;

public class RenderManager : ITickable
{
    private readonly RenderWindow RenderWindow;
    private readonly List<IToDraw> _toDraws = new();

    private Camera CurrentCamera;
    private Camera ToCamera;

    private Task CurrentTransition;
    
    public Vector2u WindowSize => RenderWindow.Size;

    public RenderManager(WindowWrapper windowWrapper)
    {
        RenderWindow = new RenderWindow(VideoMode.DesktopMode, "Framp", Styles.Default);
        
        windowWrapper.SetRenderWindow(RenderWindow);
        EntityMaster.OnAdded += OnEntityAdded;
        
        RenderWindow.Resized += OnResize;
    }

    public void Tick()
    {
        RenderWindow.DispatchEvents();

        if (CurrentCamera != null)
        {
            CurrentCamera.ApplyViewToRenderWindow(RenderWindow);
        }

        foreach (var toDraw in _toDraws)
        {
            Draw(toDraw.ToDraw);
        }
    }

    private void OnResize(object? sender, SizeEventArgs e)
    {
        CurrentCamera.SetViewSize(e.Width, e.Height);
    }

    private void Draw(Drawable drawable)
    {
        RenderWindow.Draw(drawable);    
    }

    public async void SetCamera(Camera camera, float transition = 0f)
    {
        if (transition > 0 && CurrentCamera != null)
        {
            if (CurrentTransition != null)
                await CurrentTransition;
            
            CurrentTransition = Transition(camera, transition);
        }
        else
        {
            CurrentCamera = camera;    
        }
    }

    private async Task Transition(Camera toCamera, float transition)
    {
        Vector2f startCenter = CurrentCamera.Center;
        float startSize = CurrentCamera.Size;

        Camera transitionCamera = new Camera(startCenter, startSize);
        
        CurrentCamera = transitionCamera;

        float a = 0.05f;
        
        while (CurrentCamera.Center != toCamera.Center)
        {
            CurrentCamera.SetCameraSize(Math.Clamp(CurrentCamera.Size + a, 0, toCamera.Size));
            
            CurrentCamera.SetCameraPosition(
                Vector2Utilities.MoveTo(CurrentCamera.Center, toCamera.Center, transition));

            await Task.Delay(10);
        }
        
        CurrentCamera = toCamera;
    }

    private void OnEntityAdded(Entity entity)
    {
        var toDraw = entity.Components.FindByBaseClass<IToDraw>();
        
        if(toDraw != null)
            _toDraws.Add(toDraw);
    }
}