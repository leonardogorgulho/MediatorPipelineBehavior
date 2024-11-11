using MediatR;

namespace MediatorPipelineBehavior.Api.Pipeline;

public class ExceptionPipelineBehavior<TRequest, TResponse>(
        ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> logger
    ) : IPipelineBehavior<TRequest, TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return next();
        }
        catch (Exception ex)
        {
            logger.LogError($"Error from the pipeline: {ex.Message}");
            
            throw;
        }
    }
}