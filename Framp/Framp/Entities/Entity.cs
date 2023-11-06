using Framp.DI;

namespace Framp;

public abstract class Entity
{
    public readonly ComponentsMaster Components;

    public Entity()
    {
        Components = new ComponentsMaster(this);
    }

    public virtual void OnCreated()
    {
    }

    public virtual void OnUpdate()
    {
    }
    
    public virtual void OnDestroyed()
    {
        
    }
}