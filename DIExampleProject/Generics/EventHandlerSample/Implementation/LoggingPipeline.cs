using DIExampleProject.Generics.EventHandlerSample.Interfaces;

namespace DIExampleProject.Generics.EventHandlerSample.Implementation;
public class LoggingPipeline<TEvent> : IEventPipelineBehavior<TEvent> where TEvent : IEvent
{
    public async Task HandleAsync(TEvent evt, Func<Task> next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Pipeline] Handling {typeof(TEvent).Name}");
        await next(); // Call the next handler in the pipeline
        Console.WriteLine($"[Pipeline] Finished {typeof(TEvent).Name}");
    }
}
