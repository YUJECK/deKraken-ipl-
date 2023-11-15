using deKraken.Windows;

namespace deKraken.Cameras;

public sealed class TransitionsStateMachine
{
    private CameraTransition _currentTransition;
    private readonly Queue<CameraTransition> _transitionsQueue = new();

    private readonly RenderManager _renderManager;

    public TransitionsStateMachine(RenderManager renderManager)
    {
        _renderManager = renderManager;
    }

    public Task PushTransition(CameraTransition cameraTransition)
    {
        if(cameraTransition == null)
            return null;
        
        _transitionsQueue.Enqueue(cameraTransition);
        
        if(_transitionsQueue.Count == 1)
            return Check();
        
        return null;    
    }

    private Task Check()
    {
        if (CanStartNewTransition())
        {
            return TryStartTransition();
        }

        return null;
    }

    private async Task TryStartTransition()
    {
        if(_currentTransition != null && _currentTransition.State == WorkState.Working)
            return;
        
        if (_transitionsQueue.TryPeek(out CameraTransition cameraTransition))
        {
            await cameraTransition.StartTransition(_renderManager.CurrentCamera, _renderManager);
            
            _currentTransition = null;
            _transitionsQueue.Dequeue();
            
            Check();
        }
    }

    private bool CanStartNewTransition()
        => _currentTransition == null || _currentTransition.State == WorkState.Completed;
}