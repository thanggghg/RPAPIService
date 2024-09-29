using FluentValidation;
using RP.GobalCore.Commons.Constants;
using RP.GobalCore.Commons.Enums;

namespace RP.GobalCore.Application.Validations.AffiliateSubmission
{
    //public class CreateAffiliateSubmissionCommandValidator : AbstractValidator<CreateAffiliateSubmissionCommand>
    //{
    //    public CreateAffiliateSubmissionCommandValidator()
    //    {
    //        RuleFor(command => command.ConversionId).Must(x => !string.IsNullOrEmpty(x) && x != Guid.Empty.ToString() && Guid.TryParse(x, out Guid guid)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_CONVERSION));
    //        RuleFor(command => command.GroupId).Must(x => !string.IsNullOrEmpty(x) && x != Guid.Empty.ToString() && Guid.TryParse(x, out Guid guid)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_GROUP_ID));
    //        RuleFor(command => command.OrderId).Must(x => !string.IsNullOrEmpty(Convert.ToString(x))).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_ORDER_ID));
    //        RuleFor(command => command.CreatedSubmissionTime).Must(x => x != null).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_CREATED_SUBMISSION_TIME));
    //        RuleFor(command => command.SubTotalAmount).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_SUB_TOTAL_AMOUNT));
    //        RuleFor(command => command.DiscountAmount).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_DISCOUNT_AMOUNT));
    //        RuleFor(command => command.FeeAmount).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_FEE_AMOUNT));
    //        RuleFor(command => command.TaxAmount).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_TAX_AMOUNT));
    //        RuleFor(command => command.ShippingFee).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_SHIPPPING_FEE));
    //        RuleFor(command => command.TotalAmount).Must(x => x == null || x >= 0).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_TOTAL_AMOUNT));
    //        RuleFor(command => command.OrderItems).Must(x => x.All(y => !string.IsNullOrEmpty(y.ProductId))).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_PRODUCT_ID));
    //        RuleFor(command => command.OrderItems).Must(x => x.All(y => y == null || y.SalePrice >= 0)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_SALE_PRICE));
    //        RuleFor(command => command.OrderItems).Must(x => x.All(y => y == null || y.Price >= 0)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_PRICE));
    //        RuleFor(command => command.OrderItems).Must(x => x.All(y => y == null || y.TotalPrice >= 0)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_TOTAL_PRICE));
    //        RuleFor(command => command.OrderItems).Must(x => x.All(y => y == null || y?.Quantity >= 0)).WithErrorCode(nameof(SubmissionCodeEnum.INVALID_QUANTIFY));
    //    }
    //}

}
