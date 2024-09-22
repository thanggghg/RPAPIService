using GoSell.Commissions.Application.Queries;

internal static class ValidatorExtensions
{
    public static void AddValidatorExtension(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<CreateCommissionProductModelQuery>, CreateCommissionProductModelQueryValidator>();
        builder.Services.AddScoped<IValidator<EditCommissionProductModelQuery>, EditCommissionProductModelQueryValidator>();
    }
}
