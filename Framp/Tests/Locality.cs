using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public sealed class Locality : Component
{
    public readonly Transformable Transformable;

    public Locality(Vector2f position, Vector2f scale)
    {
        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
    }
    
    public Locality(Vector2f position, Vector2f scale, float rotation)
    {
        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
        Transformable.Rotation = rotation;
    }

    public void Move(float x, float y)
        => Transformable.Position = new Vector2f(x, y);
    
    public void Move(Vector2f toPos)
        => Transformable.Position = toPos;
    
    public void Rotate(float toAngel)
        => Transformable.Rotation = toAngel;
    
    public void Scale(Vector2f toScale)
        => Transformable.Scale = toScale;
}