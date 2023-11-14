namespace Framp.Events;

public sealed class Subscriber
{
    public readonly Type SubscriptionType;
    public readonly Action<Event> OnEvent; 

    public Subscriber(Type subscriptionType, Action<Event> onEvent)
    {
        SubscriptionType = subscriptionType;
        OnEvent = onEvent;
    }
}