using Framp.Windows;
using SFML.Graphics;

namespace Framp.Tests;

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

    protected override void OnStart()
    {
        _transform = Entity.ComponentsMaster.Get<Transform>();
        
        _sprite = new Sprite(_texture);
    }

    protected override void OnUpdate()
    {
        _sprite.Scale = _transform.Transformable.Scale;
        _sprite.Rotation = _transform.Transformable.Rotation;
        _sprite.Position = _transform.Transformable.Position;
    }
}