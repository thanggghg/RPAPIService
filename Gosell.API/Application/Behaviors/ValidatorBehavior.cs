using ValidationException = GoSell.API.Exceptions.ValidationException;

namespace GoSell.API.Application.Behaviors;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                Serilog.Log.Logger.Error("Validation errors - Command: {@Command} - Errors: {@ValidationErrors}", request, failures);
                throw new ValidationException(failures);
            }
        }


        return await next();
    }
}
