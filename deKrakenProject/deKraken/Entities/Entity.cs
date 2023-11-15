using deKraken.Tests;
using deKraken.DI;
using SFML.System;

namespace deKraken;

public abstract class Entity
{
    public readonly ComponentsMaster Components;
    public Transform Transform { get; private set; }

    public Entity()
    {
        Components = new ComponentsMaster(this);
    }

    public virtual void OnCreated()
    {
        Transform = Components.Add(new Transform(new Vector2f(0, 0), new Vector2f(1, 1)));
    }

    public virtual void OnUpdate()
    {
    }
    
    public virtual void OnDestroyed()
    {
        
    }
}