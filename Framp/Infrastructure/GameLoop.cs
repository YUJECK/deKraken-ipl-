using Framp.InputSystem;
using Framp.Windows;

namespace Framp;

public class GameLoop
{
    private readonly List<ITickable> _tickableManagers = new();
    
    private readonly RenderManager _renderManager;
    private readonly WindowWrapper windowWrapper = new();

    private bool loopStarted = false;

    public GameLoop(params ITickable[] tickableManagers)
    {
        _tickableManagers.AddRange(tickableManagers);

        _renderManager = new RenderManager(windowWrapper);
        _tickableManagers.Add(_renderManager);
    }
    
    public void StartLoop()
    {
        if (loopStarted)
            return;
        
        loopStarted = true;
        
        while (_renderManager.IsOpen)
        {
            windowWrapper.Clear();
            
            _tickableManagers
                .ForEach((tickable) => tickable.Tick());
            
            EntityMaster.UpdateEntities();
            
            windowWrapper.Display();
        }
    }
}