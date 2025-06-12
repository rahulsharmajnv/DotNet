using System.Diagnostics;
using DIExampleProject.Generics.EventHandlerSample.Interfaces;

namespace DIExampleProject.Generics.EventHandlerSample.Implementation;

public class EventDispatcher
{
    private readonly IServiceProvider _provider;

    public EventDispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task DispatchAsync<TEvent>(TEvent evt, CancellationToken cancellationToken = default)
        where TEvent : IEvent
    {
        var handlers = _provider.GetServices<IEventHandler<TEvent>>();
        var pipeline = _provider.GetServices<IEventPipelineBehavior<TEvent>>().ToList();

        Func<Task> handlerChain = async () =>
        {
            foreach (var handler in handlers)
            {
                var sw = Stopwatch.StartNew();
                await handler.HandleAsync(evt, cancellationToken);
                sw.Stop();
                Console.WriteLine($"[Metrics] {handler.GetType().Name} took {sw.ElapsedMilliseconds}ms");
            }
        };

        // Compose middleware pipeline
        foreach (var behavior in pipeline.AsEnumerable().Reverse())
        {
            var next = handlerChain;
            handlerChain = () => behavior.HandleAsync(evt, next, cancellationToken);
        }

        await handlerChain();
    }
}
