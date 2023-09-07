using SFML.Window;

namespace Framp;

public static class InputSystem
{
    public static bool IsKeyPressed(Keyboard.Key key)
    {
        return Keyboard.IsKeyPressed(key);
    }
}