namespace Framp;

public static class EntityMaster
{
    private static readonly List<Entity> Entities = new();

    public static void AddEntity(Entity entity)
    {
        if (entity == null)
            throw new NullReferenceException("Null entity added");

        Entities.Add(entity);
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