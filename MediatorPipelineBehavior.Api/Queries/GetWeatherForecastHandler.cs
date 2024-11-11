using MediatorPipelineBehavior.Api.Models;
using MediatR;

namespace MediatorPipelineBehavior.Api.Queries;

public record WeatherForecastRequest(bool ThrowErrorForFun) : IRequest<WeatherForecast[]>;

public class GetWeatherForecastHandler : IRequestHandler<WeatherForecastRequest, WeatherForecast[]>
{
    public Task<WeatherForecast[]> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
    {
        if (request.ThrowErrorForFun)
            throw new Exception("Error for fun");
        
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        
        return Task.FromResult(forecast);
    }
}