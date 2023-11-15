using deKraken.Windows;
using SFML.Graphics;

namespace deKraken.Tests;

public sealed class SpriteRenderer : Component, IToDraw
{
    private Sprite _sprite;

    private Transform _transform;
    private Texture _texture;

    public Drawable ToDraw => _sprite;

    public SpriteRenderer(Texture texture)
    {
        _texture = texture;
    }

    public void ChangeTexture(Texture texture)
    {
        _texture = texture;
        _sprite.Texture = _texture;
    }
    public void ChangeColor(Color color)
    {
        _sprite.Color = color;
    }

    protected override void OnStart()
    {
        _transform = Entity.Components.Get<Transform>();
        
        _sprite = new Sprite(_texture);
    }

    protected override void OnUpdate()
    {
        _sprite.Scale = _transform.Scale;
        _sprite.Rotation = _transform.Rotation;
        _sprite.Position = _transform.Position;
    }
}