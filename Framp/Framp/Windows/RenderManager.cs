using Framp.InputSystem;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Windows;

public class RenderManager : ITickable
{
    private readonly RenderWindow RenderWindow;
    private readonly List<IToDraw> _toDraws = new();
    
    public bool IsOpen => RenderWindow.IsOpen;
    public Vector2u WindowSize => RenderWindow.Size;

    public RenderManager(WindowWrapper windowWrapper)
    {
        RenderWindow = new RenderWindow(VideoMode.DesktopMode, "Framp");
        RenderWindow.Size = new Vector2u(1000, 600);
        
        windowWrapper.SetRenderWindow(RenderWindow);
        EntityMaster.OnAdded += OnEntityAdded;
    }

    private void OnEntityAdded(Entity entity)
    {
        var toDraw = entity.ComponentsMaster.FindByBaseClass<IToDraw>();
        
        if(toDraw != null)
            _toDraws.Add(toDraw);
    }
    public void Draw(Drawable drawable)
    {
        RenderWindow.Draw(drawable);    
    }
    
    public void SetCamera(Camera camera)
        => RenderWindow.SetView(camera.View);

    public void Tick()
    {
        foreach (var toDraw in _toDraws)
        {
            Draw(toDraw.ToDraw);
        }
    }
}