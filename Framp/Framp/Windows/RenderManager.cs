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
    
    public Vector2u WindowSize => RenderWindow.Size;

    public RenderManager(WindowWrapper windowWrapper)
    {
        RenderWindow = new RenderWindow(VideoMode.DesktopMode, "Framp");
        
        windowWrapper.SetRenderWindow(RenderWindow);
        EntityMaster.OnAdded += OnEntityAdded;
    }

    public void Tick()
    {
        RenderWindow.SetView(CurrentCamera.View);
        Console.WriteLine(CurrentCamera.View.Center);
        
        foreach (var toDraw in _toDraws)
        {
            Draw(toDraw.ToDraw);
        }
    }

    private void Draw(Drawable drawable)
    {
        RenderWindow.Draw(drawable);    
    }

    public void SetCamera(Camera camera)
    {
        CurrentCamera = camera;
    }

    private void OnEntityAdded(Entity entity)
    {
        var toDraw = entity.Components.FindByBaseClass<IToDraw>();
        
        if(toDraw != null)
            _toDraws.Add(toDraw);
    }
}