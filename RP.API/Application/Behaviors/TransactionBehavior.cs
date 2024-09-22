namespace RP.API.Application.Behaviors;

using Microsoft.Extensions.Logging;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;

    public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentException(nameof(ILogger));
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var typeName = "";

        try
        {
            return next();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Handling transaction for {CommandName} ({@Command})", typeName, request);
            Serilog.Log.Logger.Error(ex, "Error Handling transaction for {CommandName} ({@Command})", typeName, request);
            throw;
        }
    }
}
