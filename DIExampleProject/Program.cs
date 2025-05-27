using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DIExampleProject.Interfaces;
using DIExampleProject.Implementation;
using DIExampleProject.MiddleWare;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DI Registrations
builder.Services.AddScoped<IDateTimeService, DateTimeService>();
builder.Services.AddScoped<IGuidService, GuidService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageServiceV2, MessageServiceV2>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseRequestLogging(); // Use the custom middleware
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();