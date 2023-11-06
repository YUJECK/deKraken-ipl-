using Framp.DI;

namespace Framp;

public sealed class ComponentsMaster
{
    public readonly Entity Owner;
    
    private readonly Dictionary<Type, Component> _components = new();
    [Inject] private Injector _injector;

    public ComponentsMaster(Entity owner)
        => Owner = owner;

    public TComponent Get<TComponent>()
        where TComponent : Component
    {
        return _components[typeof(TComponent)] as TComponent;
    }

    public TClass FindByBaseClass<TClass>()
        where TClass : class
    {
        foreach (var componentPair in _components)
        {
            if (componentPair.Value is TClass asInterface)
                return asInterface;
        }

        return null;
    }
    
    public void UpdateAll()
    {
        foreach (var component in _components)
            component.Value.Update();
    }
    
    public void Add<TComponent>(TComponent component)
        where TComponent : Component
    {
        if (component == null)
            throw new NullReferenceException("Null component tried to add");
        
        _components.Add(typeof(TComponent), component);
        _injector.Inject(component);
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