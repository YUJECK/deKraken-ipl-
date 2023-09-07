namespace Framp;

public sealed class EntityMaster
{
    private readonly List<Entity> _entities;

    public EntityMaster(List<Entity> entities)
    {
        _entities = entities;
    }

    public void AddEntity(Entity entity)
    {
        if (entity == null)
            throw new NullReferenceException("Null entity added");

        _entities.Add(entity);
        entity.OnCreated();
    }

    public void DestroyEntity(Entity entity)
    {
        if (entity == null)
            throw new NullReferenceException("Null entity removed");
        
        _entities.Remove(entity);
        entity.OnDestroyed();
    }

    public void UpdateEntities()
    {
        foreach (var entity in _entities)
        {
            entity.OnUpdate();
            entity.ComponentsMaster.UpdateAll();
        }
    }
}