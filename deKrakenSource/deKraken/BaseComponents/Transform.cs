using SFML.Graphics;
using SFML.System;

namespace deKraken.Tests;

public sealed class Transform : Component
{
    private readonly Transformable Transformable;

    public Transform(Vector2f position, Vector2f scale)
    {
        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
    }

    public Transform(Vector2f position, Vector2f scale, float rotation)
    {
        Transformable = new Transformable();
        
        Transformable.Position = position;
        Transformable.Scale = scale;
        Transformable.Rotation = rotation;
    }

    public Vector2f Position => Transformable.Position;
    public float Rotation => Transformable.Rotation;
    public Vector2f Scale => Transformable.Scale;

    public void Move(float x, float y)
        => Transformable.Position = new Vector2f(x, y);

    public void Move(Vector2f toPos)
        => Transformable.Position = toPos;

    public void Rotate(float toAngel)
        => Transformable.Rotation = toAngel;

    public void ScaleIt(Vector2f toScale)
        => Transformable.Scale = toScale;
}