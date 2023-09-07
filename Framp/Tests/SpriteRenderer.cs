using SFML.Graphics;

namespace Framp.Tests;

public sealed class SpriteRenderer : Component
{
    private Sprite _sprite;

    private Locality _locality;
    private Texture _texture;

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
        _locality = Entity.ComponentsMaster.Get<Locality>();
        
        _sprite = new Sprite(_texture);
    }

    protected override void OnUpdate()
    {
        _sprite.Scale = _locality.Transformable.Scale;
        _sprite.Rotation = _locality.Transformable.Rotation;
        _sprite.Position = _locality.Transformable.Position;
        
        _sprite.Draw(WindowWrapper.RenderWindow, RenderStates.Default); 
    }
}