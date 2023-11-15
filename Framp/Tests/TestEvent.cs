using Framp.Events;

namespace Framp.Tests;

public class TestEvent : Event
{
    public int i = 0;
    
    public override void OnPushed()
    {
        Console.WriteLine("Pushed");
    }

    public override void OnCompleted()
    {
        Console.WriteLine("Completed");
    }

    public override void Tick()
    {
        i++;
    }
}