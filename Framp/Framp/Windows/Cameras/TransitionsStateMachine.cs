using Framp.Windows;

namespace Framp.Cameras;

public sealed class TransitionsStateMachine
{
    private CameraTransition _currentTransition;
    private readonly Queue<CameraTransition> _transitionsQueue = new();

    private readonly RenderManager _renderManager;

    public TransitionsStateMachine(RenderManager renderManager)
    {
        _renderManager = renderManager;
    }

    public void PushTransition(CameraTransition cameraTransition)
    {
        if(cameraTransition == null)
            return;
        
        _transitionsQueue.Enqueue(cameraTransition);
        
        if(_transitionsQueue.Count == 1)
            Check();
    }

    private void Check()
    {
        if (_currentTransition == null || _currentTransition.State == WorkState.Completed)
        {
            TryStartTransition();
        }
    }

    private async void TryStartTransition()
    {
        if(_currentTransition != null && _currentTransition.State == WorkState.Working)
            return;
        
        if (_transitionsQueue.TryPeek(out CameraTransition cameraTransition))
        {
            await cameraTransition.StartTransition(_renderManager.CurrentCamera,
                _renderManager);
            
            _currentTransition = null;
            _transitionsQueue.Dequeue();
            
            Check();
        }
    }
}