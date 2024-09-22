
using FluentValidation;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Models.Requests;

namespace GoSell.Affiliate.Tracking.Validations.AffiliateTheme
{
    public class UpdateThemeRequestValidator : AbstractValidator<UpdateThemeRequest>
    {
        public UpdateThemeRequestValidator()
        {
            RuleFor(command => command.Id).NotNull().NotEmpty();
            RuleFor(command => command.ColorId).NotNull().NotEmpty();
            RuleFor(command => command.CoverImage).NotNull().NotEmpty();
            RuleFor(command => command.Logo).NotNull().NotEmpty();
            RuleFor(command => command.IsPublished).NotNull();
        }
    }

}
