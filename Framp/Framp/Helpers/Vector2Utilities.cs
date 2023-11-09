using SFML.System;

namespace Framp;

public static class Vector2Utilities
{
    public static Vector2f MoveTo(Vector2f current, Vector2f to, float speed)
    {
        float resultSpeed = speed / 100;

        Vector2f distance = to - current;
        
        return current + distance * resultSpeed;
    }
    
}