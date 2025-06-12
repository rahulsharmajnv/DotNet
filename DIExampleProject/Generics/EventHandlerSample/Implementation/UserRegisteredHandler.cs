using DIExampleProject.Generics.EventHandlerSample.Interfaces;
namespace DIExampleProject.Generics.EventHandlerSample.Implementation;
public class UserRegisteredHandler : IEventHandler<UserRegisteredEvent>
{
    public Task HandleAsync(UserRegisteredEvent evt, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Handler] Welcome {evt.UserName}!");
        return Task.CompletedTask;
    }
}
