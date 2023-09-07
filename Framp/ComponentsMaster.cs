namespace Framp;

public sealed class ComponentsMaster
{
    public readonly Entity Owner;
    
    private Dictionary<Type, Component> _components = new();

    public ComponentsMaster(Entity owner)
        => Owner = owner;
    
    public void Add<TComponent>(TComponent component)
        where TComponent : Component
    {
        if (component == null)
            throw new NullReferenceException("Null component tried to add");
        
        _components.Add(typeof(TComponent), component);
        component.Start(Owner);
    }

    public void Remove<TComponent>()
        where TComponent : Component
    {
        if(!_components.Remove(typeof(TComponent)))
           Console.WriteLine("!!!Component wasnt found!!!");
    }

    public void Replace<TComponent>(TComponent component)
        where TComponent : Component
    {
        if (component == null)
            throw new NullReferenceException("Null component tried to replace");

        if (!_components.ContainsKey(typeof(TComponent)))
        {
            Console.WriteLine("!!!Component wasnt found!!!");
            return;
        }
        
        _components[typeof(TComponent)].Remove();
        
        _components[typeof(TComponent)] = component;

        component.Start(Owner);
    }
}