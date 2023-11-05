using Core.Primitives;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Behavior;

// TODO use better practice for logging
public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
            when (exception is not DomainException)
        {
            _logger.LogError(exception, "Unhandled exception: in {@Request} details: {Message} ", request, exception.Message);
            throw;
        }
        
        catch (Exception ex)
            when (ex is DomainException)

        {
            _logger.LogInformation(ex, "DomainException: {Message}", ex.Message);
            throw;
        }
    }
}