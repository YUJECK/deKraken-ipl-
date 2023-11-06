using SFML.Graphics;

namespace Framp;

public class WindowWrapper
{
    private RenderWindow _renderWindow;

    public void SetRenderWindow(RenderWindow renderWindow)
    {   
        _renderWindow = renderWindow;
    }

    public bool IsOpen => _renderWindow.IsOpen;
    
    public void Clear()
    {
        _renderWindow.Clear();
    }

    public void Display()
    {
        _renderWindow.Display();
    }
}