namespace Framp;

public abstract class Entity
{
    public readonly ComponentsMaster ComponentsMaster;

    public Entity()
    {
        ComponentsMaster = new ComponentsMaster(this);
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