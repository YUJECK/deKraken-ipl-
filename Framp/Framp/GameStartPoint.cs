using Framp.Tests;

namespace Framp;

public class GameStartPoint
{
    private void OnStart()
    {
        EntityMaster.SpawnEntity(new TestEntity());
        EntityMaster.SpawnEntity(new StaticSprite());
    }
}