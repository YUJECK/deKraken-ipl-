using System.Reflection;
using Framp.DI;
using Framp.InputSystem;
// ReSharper disable All

namespace Framp.Infrastructure.ServicesManagement;

public class ServicesRegistry
{
    private readonly Dictionary<Type, object> _allServices = new();
    private readonly List<ITickableService> _tickableServices = new();

    public void RegisterService<TService>(TService service)
    {
        if (service == null)
        {
            Console.WriteLine("You tried to register null service");
            return;
        }
        
        _allServices.Add(typeof(TService), service);
        
        if(service is ITickableService tickableService)
            _tickableServices.Add(tickableService);
    }
    
    public void Inject(object toInject)
    {
        var type = toInject.GetType();

        var allMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        foreach (var info in allMethods)
        {
            foreach (var attribute in info.GetCustomAttributes())
            {
                if (attribute is InjectAttribute)
                {
                    var parameters = new List<object>();
                    
                    foreach (var parameter in info.GetParameters())
                    {
                        parameters.Add(Get(parameter.ParameterType));
                    }

                    type
                        .GetMethod(info.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(toInject, parameters.ToArray());
                }
            }
        }
    }
    
    private object Get(Type type)
    {
        return _allServices[type];
    }
    
    public void TickAll()
    {
        foreach (var service in _tickableServices)
        {
            service.Tick();
        }
    }
}