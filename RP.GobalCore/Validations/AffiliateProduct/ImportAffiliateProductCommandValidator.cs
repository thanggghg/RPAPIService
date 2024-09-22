using FluentValidation;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Validations.AffiliateProduct
{
    public class ImportAffiliateProductCommandValidator : AbstractValidator<ImportAffiliateProductCommand>
    {
        public ImportAffiliateProductCommandValidator(ILogger<ImportAffiliateProductCommandValidator> logger)
        {
            RuleFor(command => command.File).NotNull().NotEmpty();

            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace("INSTANCE Config - {ClassName}", GetType().Name);
            }
        }
    }
}
