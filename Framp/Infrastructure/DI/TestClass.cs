using Framp.Infrastructure.ServicesManagement;
using Framp.Tests;

namespace Framp.DI;

public class TestClass
{
    [Inject]
    public void INJECT(TestEntity entity, ServicesRegistry registry)
    {
        Console.WriteLine(entity.GetType().ToString() + registry.GetType().ToString());
        
    }
    
}