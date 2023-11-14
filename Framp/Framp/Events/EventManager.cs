using Framp.InputSystem;

namespace Framp.Events;

public sealed class EventManager : ITickable
{
    private readonly Dictionary<Type, Event> _currentEvents = new();

    private readonly Dictionary<Type, List<Subscriber>> _subscribers = new();

    public void Tick()
    {
        foreach (var eventPair in _currentEvents)
            eventPair.Value.Tick();
    }

    public void PushEvent<TEvent>(TEvent eventToPush)
        where TEvent : Event
    {
        if(_currentEvents.ContainsKey(typeof(TEvent)))
            return;
        
        _currentEvents.Add(typeof(TEvent), eventToPush);
        eventToPush.OnEventCompleted += OnEventCompleted;
        
        eventToPush.OnPushed();
        InvokeSubscribers<TEvent>();
    }

    public Subscriber SubscribeOnEvent<TEvent>(Action<Event> action)
        where TEvent : Event
    {
        var subscriber = new Subscriber(typeof(TEvent), action);

        if (_subscribers.TryAdd(typeof(TEvent), new List<Subscriber>() { subscriber }))
            return subscriber;

        _subscribers[typeof(TEvent)].Add(subscriber);

        return subscriber;
    }
    
    public void UnsubscribeOnEvent(Subscriber subscriber)
    {
        _subscribers.Remove(subscriber.SubscriptionType);
    }

    private void InvokeSubscribers<TEvent>()
        where TEvent : Event
    {
        if (!_subscribers.ContainsKey(typeof(TEvent))) 
            return;

        var subscriberEvent = _currentEvents[typeof(TEvent)];

        foreach (var subscriber in _subscribers[typeof(TEvent)])
        {
            subscriber.OnEvent?.Invoke(subscriberEvent);
        }
    }

    private void OnEventCompleted(Event completedEvent)
    {
        _currentEvents.Remove(completedEvent.GetType());
        
        completedEvent.OnEventCompleted -= OnEventCompleted;
        completedEvent.OnCompleted();
    }
}