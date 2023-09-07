using SFML.Graphics;
using SFML.System;

namespace Framp.Tests;

public sealed class Locality : Component
{
    public Vector2f Position;
    public Vector2f Scale;

    public Transformable Transformable;

    public Locality(Vector2f position, Vector2f scale)
    {
        Position = position;
        Scale = scale;

        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
    }
    
    public Locality(Vector2f position, Vector2f scale, float rotation)
    {
        Position = position;
        Scale = scale;

        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
    }
}