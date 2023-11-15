using deKraken.Infrastructure.ServicesManagement;
using deKraken.Windows;
using deKraken.InputSystem;

namespace deKraken;

public class GameLoop
{
    private readonly WindowWrapper _windowWrapper = new();

    private bool loopStarted = false;
    private readonly ServicesRegistry _servicesRegistry;

    public GameLoop(ServicesRegistry servicesRegistry)
    {
        _servicesRegistry = servicesRegistry;
        _servicesRegistry.RegisterService(new RenderManager(_windowWrapper));
    }
    
    public void StartLoop(Action OnGameLoopStarted)
    {
        if (loopStarted)
            return;
        
        GameLoopLogic(OnGameLoopStarted);
    }

    private void GameLoopLogic(Action OnGameLoopStarted)
    {
        loopStarted = true;
        
        OnGameLoopStarted?.Invoke();
        
        while (_windowWrapper.IsOpen)
        {
            _windowWrapper.Clear();
            
            _servicesRegistry.Tick();
            
            EntityMaster.UpdateEntities();
            
            _windowWrapper.Display();
        }
    }
}