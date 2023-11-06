using System.Reflection;
using Framp.Infrastructure.ServicesManagement;

namespace Framp.DI;

public class Injector
{
    private RegistryService _registryService;

    public Injector(RegistryService registryService)
    {
        _registryService = registryService;
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
                        parameters.Add(_registryService.Get(parameter.ParameterType));
                    }

                    type
                        .GetMethod(info.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(toInject, parameters.ToArray());
                }
            }
        }
        
        var allFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        foreach (var info in allFields)
        {
            foreach (var attribute in info.GetCustomAttributes())
            {
                if (attribute is InjectAttribute)
                {
                    info.SetValue(toInject, _registryService.Get(info.FieldType));
                }
            }
        }
    }

}