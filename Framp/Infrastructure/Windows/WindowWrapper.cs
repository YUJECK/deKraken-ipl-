using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Windows;

public static class WindowWrapper
{
    public static readonly RenderWindow RenderWindow;
    
    static WindowWrapper()
    {
        RenderWindow = new RenderWindow(VideoMode.DesktopMode, "Framp");

        RenderWindow.Size = new Vector2u(1000, 600);
    }

    public static void SetCamera(Camera camera)
    {
        RenderWindow.SetView(camera.View);
    }
    
    public static Vector2u WindowSize()
        => RenderWindow.Size;
}