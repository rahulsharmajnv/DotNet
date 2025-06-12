using DIExampleProject.Generics.EventHandlerSample.Interfaces;
namespace DIExampleProject.Generics.EventHandlerSample.Implementation;
public class UserRegisteredEvent : IEvent {
    public string UserName { get; set; }
}