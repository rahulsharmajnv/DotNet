namespace DIExampleProject.Generics.EventHandlerSample.Interfaces;
public interface IEventPipelineBehavior<TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent evt, Func<Task> next, CancellationToken cancellationToken);
}
