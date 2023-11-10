using SFML.System;

namespace Framp;

public static class Vector2Utilities
{
    public static Vector2f MoveTo(Vector2f current, Vector2f to, float speed)
    {
        Vector2f direction = to - current;
        
        float distance = Distance(direction);

        if (distance <= 1)
            return to;
        
        speed = speed / 100;
        
        return speed * direction + current; 
    }
    
    public static float Distance(Vector2f first, Vector2f second)
    {
        Vector2f direction = second - first;

        return MathF.Sqrt(MathF.Pow(direction.X, 2) + MathF.Pow(direction.Y, 2));
    }
    
    public static float Distance(Vector2f direction)
    {
        return MathF.Sqrt(MathF.Pow(direction.X, 2) + MathF.Pow(direction.Y, 2));
    }
}