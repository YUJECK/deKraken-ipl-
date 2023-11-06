using System.Reflection;
using Framp.DI;
using Framp.InputSystem;
// ReSharper disable All

namespace Framp.Infrastructure.ServicesManagement;

public class ServicesRegistry : ITickable
{
    private readonly Dictionary<Type, object> _allServices = new();
    private readonly List<ITickable> _tickableServices = new();

    private Injector _injector;

    public ServicesRegistry()
    {
        RegisterService<ServicesRegistry>(this);
        _tickableServices.Remove(this);
        RegisterService<Injector>(_injector);
    }

    public void RegisterService<TService>(TService service)
    {
        if (service == null)
        {
            Console.WriteLine("You tried to register null service");
            return;
        }
        
        _allServices.Add(typeof(TService), service);
        
        if(service is ITickable tickableService)
            _tickableServices.Add(tickableService);

        _injector = new(this);
        
        EntityMaster.SetContainer(_injector);
    }

    public void UnregisterService<TService>()
    {
        if (_allServices.ContainsKey(typeof(TService)) == null)
        {
            Console.WriteLine("You tried to register null service");
            return;
        }

        var service = _allServices[typeof(TService)];
        _allServices.Remove(typeof(TService));
        
        if(service is ITickable tickableService)
            _tickableServices.Remove(tickableService);

        _injector = new(this);
        
        EntityMaster.SetContainer(_injector);
    }
    
    public object Get(Type type)
    {
        return _allServices[type];
    }
    public TService Get<TService>()
        where TService : class
    {
        return _allServices[typeof(TService)] as TService;
    }
    
    public void Tick()
    {
        foreach (var service in _tickableServices)
        {
            service.Tick();
        }
    }
}