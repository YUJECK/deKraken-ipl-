using System.Reflection;
using Framp.DI;
using Framp.InputSystem;
// ReSharper disable All

namespace Framp.Infrastructure.ServicesManagement;

public class RegistryService : ITickable
{
    private readonly Dictionary<Type, object> _allServices = new();
    private readonly List<ITickable> _tickableServices = new();

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
    
    public void Tick()
    {
        foreach (var service in _tickableServices)
        {
            service.Tick();
        }
    }
}