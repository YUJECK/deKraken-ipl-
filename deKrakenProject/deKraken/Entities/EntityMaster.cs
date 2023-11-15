using deKraken.DI;
using deKraken.Infrastructure.ServicesManagement;

namespace deKraken;

public static class EntityMaster
{
    private static readonly List<Entity> Entities = new();
    private static Injector _injector;

    public static event Action<Entity> OnAdded;
    
    public static void SetContainer(Injector injector)
    {
        _injector = injector;
    }
    
    public static void SpawnEntity(Entity entity)
    {
        if (entity == null)
        {
            Console.WriteLine("! You tried to spawn null entity");
        }

        Entities.Add(entity);
        
        _injector.Inject(entity);
        _injector.Inject(entity.Components);

        entity.OnCreated();
        
        OnAdded?.Invoke(entity);
    }

    public static void DestroyEntity(Entity entity)
    {
        if (entity == null)
        {
            Console.WriteLine("! You tried to destroy null entity");
        }
        
        Entities.Remove(entity);
        entity.OnDestroyed();
    }

    public static void UpdateEntities()
    {
        foreach (var entity in Entities)
        {
            entity.OnUpdate();
            entity.Components.UpdateAll();
        }
    }
}