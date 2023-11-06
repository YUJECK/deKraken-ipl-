using System.Reflection;
using Framp.Infrastructure.ServicesManagement;

namespace Framp.DI;

public class Injector
{
    private ServicesRegistry _servicesRegistry;

    public Injector(ServicesRegistry servicesRegistry)
    {
        _servicesRegistry = servicesRegistry;
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
                        parameters.Add(_servicesRegistry.Get(parameter.ParameterType));
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
                    info.SetValue(toInject, _servicesRegistry.Get(info.FieldType));
                }
            }
        }
    }

}