using Framp.Infrastructure.ServicesManagement;

namespace Framp;

public static class EntityMaster
{
    private static readonly List<Entity> Entities = new();
    private static RegistryService _registryService;

    public static event Action<Entity> OnAdded;
    
    public static void SetContainer(RegistryService registryService)
    {
        _registryService = registryService;
    }
    
    public static void AddEntity(Entity entity)
    {
        if (entity == null)
            Console.WriteLine("! You tried to spawn null entity");

        Entities.Add(entity);
        _registryService.Inject(entity);

        entity.OnCreated();
        
        OnAdded?.Invoke(entity);
    }

    public static void DestroyEntity(Entity entity)
    {
        if (entity == null)
            throw new NullReferenceException("Null entity removed");
        
        Entities.Remove(entity);
        entity.OnDestroyed();
    }

    public static void UpdateEntities()
    {
        foreach (var entity in Entities)
        {
            entity.OnUpdate();
            entity.ComponentsMaster.UpdateAll();
        }
    }
}