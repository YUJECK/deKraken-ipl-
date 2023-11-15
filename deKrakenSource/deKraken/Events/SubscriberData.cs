namespace deKraken.Events;

public abstract class SubscriberData
{
    public Type SubscriptionType { get; protected init; }

    public abstract void InvokeSubscription(Event nonTypedEvent);
}