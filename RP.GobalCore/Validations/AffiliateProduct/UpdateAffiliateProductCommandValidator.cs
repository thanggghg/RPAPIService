using FluentValidation;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Validations.AffiliateProduct
{
    public class UpdateAffiliateProductCommandValidator : AbstractValidator<UpdateAffiliateProductCommand>
    {
        public UpdateAffiliateProductCommandValidator(ILogger<UpdateAffiliateProductCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotNull().NotEmpty();
            RuleFor(command => command.ProductUrl).NotNull().NotEmpty();
            RuleFor(command => command.IsOutOfStock).NotNull();

            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace("INSTANCE Config - {ClassName}", GetType().Name);
            }
        }
    }
}
