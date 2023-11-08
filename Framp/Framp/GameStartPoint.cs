using Framp.Tests;

namespace Framp;

public class GameStartPoint
{
    private void OnStart()
    {
        EntityMaster.SpawnEntity(new StaticSprite());
        EntityMaster.SpawnEntity(new PlayerEntity());
    }
}