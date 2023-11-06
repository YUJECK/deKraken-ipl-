using Framp.Tests;

namespace Framp;

public class GameStartPoint
{
    private void OnStart()
    {
        EntityMaster.SpawnEntity(new PlayerEntity());
        EntityMaster.SpawnEntity(new StaticSprite());
    }
}