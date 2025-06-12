using DIExampleProject.Generics.EventHandlerSample.Interfaces;

namespace DIExampleProject.Generics.EventHandlerSample.Implementation;
public class OrderPlacedEvent : IEvent
{
    public int OrderId { get; set; }
}