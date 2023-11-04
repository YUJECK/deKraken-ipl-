using Framp.Infrastructure.ServicesManagement;

namespace Framp;

public static class EntityMaster
{
    private static readonly List<Entity> Entities = new();
    private static ServicesRegistry _registry;
    
    public static void SetContainer(ServicesRegistry servicesRegistry)
    {
        _registry = servicesRegistry;
    }
    
    public static void AddEntity(Entity entity)
    {
        if (entity == null)
            throw new NullReferenceException("Null entity added");

        Entities.Add(entity);
        _registry.Inject(entity);
        
        entity.OnCreated();
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