using deKraken.Tests;

namespace deKraken;

public class GameStartPoint
{
    private void OnStart()
    {
        EntityMaster
            .SpawnEntity(new StaticSprite());
        
        EntityMaster
            .SpawnEntity(new PlayerEntity());
    }
}