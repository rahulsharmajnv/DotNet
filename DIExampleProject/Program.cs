using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DIExampleProject.Interfaces;
using DIExampleProject.Implementation;
using DIExampleProject.MiddleWare;
using DIExampleProject.Generics.EventHandlerSample.Interfaces;
using DIExampleProject.Generics.EventHandlerSample.Implementation;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DI Registrations
var services = builder.Services;
builder.Services.AddScoped<IDateTimeService, DateTimeService>();
builder.Services.AddScoped<IGuidService, GuidService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageServiceV2, MessageServiceV2>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEventHandler<UserRegisteredEvent>, UserRegisteredHandler>();
services.AddTransient<IEventHandler<IEvent>, GenericAuditHandler>();

services.AddTransient(typeof(IEventPipelineBehavior<>), typeof(LoggingPipeline<>));

services.AddSingleton<EventDispatcher>();
var app = builder.Build();
app.UseRequestLogging(); // Use the custom middleware
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();