using DIExampleProject.Generics.EventHandlerSample.Interfaces;

namespace DIExampleProject.Generics.EventHandlerSample.Interfaces;
public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent evt, CancellationToken cancellationToken);
}
