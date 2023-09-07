namespace Framp;

public abstract class Component
{
    protected Entity Entity { get; private set; }
    
    public void Start(Entity entity)
    {
        Entity = entity;
        OnStart();
    }

    public void Update()
    {
        OnUpdate();    
    }

    public void Remove()
    {
        OnRemoved();
    }
    
    protected virtual void OnStart() { }
    
    protected virtual void OnUpdate() { }
    
    protected virtual void OnRemoved() { }
}