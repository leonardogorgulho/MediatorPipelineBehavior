using System.Reflection;
using MediatorPipelineBehavior.Api.Endpoints;
using MediatorPipelineBehavior.Api.Pipeline;
using MediatorPipelineBehavior.Api.Queries;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// register the pipelines 
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogPipelineBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionPipelineBehavior<,>));

// add the mediator
builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapWeatherForecastEndpoint();

app.Run();

