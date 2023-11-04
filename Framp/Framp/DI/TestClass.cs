using Framp.Infrastructure.ServicesManagement;
using Framp.Tests;

namespace Framp.DI;

public class TestClass
{
    [Inject]
    public void INJECT(TestEntity entity, RegistryService registryService)
    {
        Console.WriteLine(entity.GetType().ToString() + registryService.GetType().ToString());
        
    }
    
}