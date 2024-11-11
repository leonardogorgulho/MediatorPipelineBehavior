using MediatorPipelineBehavior.Api.Queries;
using MediatR;

namespace MediatorPipelineBehavior.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoint(this WebApplication app)
    {
        app.MapGet("/weatherforecast", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new WeatherForecastRequest(false));
                return TypedResults.Ok(result);
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.MapGet("/weatherforecasterror", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new WeatherForecastRequest(true));
                return TypedResults.Ok(result);
            })
            .WithName("GetWeatherForecastError")
            .WithOpenApi()
            .WithSummary("This will throw an error");
    }
}