using deKraken.Tests;

namespace deKraken.Events;

public class TypedSubscriberData<TEvent> : SubscriberData
    where TEvent : Event
{
    private readonly Action<TEvent> _subscription;
    
    public TypedSubscriberData(Action<TEvent> subscription)
    {
        SubscriptionType = typeof(TEvent);
        _subscription = subscription;
    }

    public override void InvokeSubscription(Event nonTypedEvent)
    {
        _subscription?.Invoke(nonTypedEvent as TEvent);
    }
}