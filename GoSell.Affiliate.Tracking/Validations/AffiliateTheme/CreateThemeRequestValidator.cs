
using FluentValidation;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Models.Requests;

namespace GoSell.Affiliate.Tracking.Validations.AffiliateTheme
{
    public class CreateThemeRequestValidator : AbstractValidator<CreateThemeRequest>
    {
        public CreateThemeRequestValidator()
        {
            RuleFor(command => command.ColorId).NotNull().NotEmpty();
            RuleFor(command => command.StoreId).NotNull().NotEmpty();
            RuleFor(command => command.CoverImage).NotNull().NotEmpty();
            RuleFor(command => command.Logo).NotNull().NotEmpty();
            RuleFor(command => command.IsPublished).NotNull();
        }
    }

}
