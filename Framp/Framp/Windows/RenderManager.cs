using Framp.Cameras;
using Framp.InputSystem;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Windows;

public class RenderManager : ITickable
{
    private readonly RenderWindow RenderWindow;
    private readonly List<IToDraw> _toDraws = new();

    public Camera CurrentCamera { get; private set; }
    private readonly TransitionsStateMachine _transitionsStateMachine; 
    
    public Vector2u WindowSize => RenderWindow.Size;

    public RenderManager(WindowWrapper windowWrapper)
    {
        _transitionsStateMachine = new TransitionsStateMachine(this);
        RenderWindow = new RenderWindow(VideoMode.DesktopMode, "Framp", Styles.Default);
        
        windowWrapper.SetRenderWindow(RenderWindow);
        EntityMaster.OnAdded += OnEntityAdded;
        
        RenderWindow.Resized += OnResize;
        RenderWindow.Closed += OnClosed;
    }

    public void Tick()
    {
        RenderWindow.DispatchEvents();
        
        foreach (var toDraw in _toDraws)
        {
            Draw(toDraw.ToDraw);
        }
        
        if (CurrentCamera != null)
        {
            CurrentCamera.ApplyViewToRenderWindow(RenderWindow);
        }
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        RenderWindow.Close();
    }

    private void OnResize(object? sender, SizeEventArgs e)
    {
        if (CurrentCamera != null)
        {
            CurrentCamera.SetViewSize(e.Width, e.Height);
        }
    }

    private void Draw(Drawable drawable)
    {
        RenderWindow.Draw(drawable);    
    }

    public void SetCamera(Camera camera)
    {
        if(camera == null)
            return;
        
        CurrentCamera = camera;    
        CurrentCamera.SetViewSize(RenderWindow.Size.X, RenderWindow.Size.Y);
    }

    public void PushTransition(CameraTransition transition)
    {
        if (transition != null && CurrentCamera != null)
        {
            _transitionsStateMachine.PushTransition(transition);
        }
    }

    private void OnEntityAdded(Entity entity)
    {
        var toDraw = entity.Components.FindByBaseClass<IToDraw>();
        
        if(toDraw != null)
            _toDraws.Add(toDraw);
    }
}