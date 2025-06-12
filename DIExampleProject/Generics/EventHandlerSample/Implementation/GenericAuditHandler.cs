using DIExampleProject.Generics.EventHandlerSample.Interfaces;
namespace DIExampleProject.Generics.EventHandlerSample.Implementation;

public class GenericAuditHandler : IEventHandler<IEvent>
{

    public Task HandleAsync(IEvent evt, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Audit] Event: {evt.GetType().Name}");
        return Task.CompletedTask;
    }
}