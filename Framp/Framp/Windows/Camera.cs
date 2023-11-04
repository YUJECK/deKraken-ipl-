using SFML.Graphics;
using SFML.System;

namespace Framp.Windows;

public class Camera
{
    public readonly View View;

    public Camera()
    {
        View = new View(new Vector2f(0f, 0f), new Vector2f(1000, 600f));
    }
}