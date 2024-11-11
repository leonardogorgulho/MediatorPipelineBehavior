using MediatR;

namespace MediatorPipelineBehavior.Api.Pipeline;

public class LogPipelineBehavior<TRequest, TResponse>(ILogger<LogPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling request {typeof(TRequest).Name} with {typeof(TResponse).Name}");
        
        var response = await next();

        logger.LogInformation($"Handled request {typeof(TRequest).Name} with {typeof(TResponse).Name}");
        
        return response;
    }
}