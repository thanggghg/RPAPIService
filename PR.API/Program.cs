using GoSell.API.Routes;
using GoSell.Commissions.Extensions;
using GoSell.CommonHistory.Extensions;
using GoSell.CommonTicket.Extensions;
using GoSell.EmailSender.Extensions;
using GoSell.EWarranty.Extensions;
using GoSell.Exports.Extensions;
using GoSell.FBBulkPosting.Extension;
using GoSell.Forum.Extensions;
using GoSell.Library.Extensions.Localization;
using GoSell.Orders.Extension;
using GoSell.Payments.Extension;
using GoSell.SupportTicket.Extension;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.AddApplicationServices();
builder.AddSocialServices();
builder.AddPaymentExtension();
builder.AddOrderExtension();
builder.AddWarrantyExtension();
builder.AddExportExtension();
builder.AddLocalizationExtension();
builder.AddAutoMapperExtension();
builder.AddValidatorExtension();
builder.AddAnalysisExtension();
builder.AddCommissionExtension();
builder.AddCommentServices();
builder.AddAffiliateTrackingExtension();
builder.AddAffiliateAuthenticationServices();
builder.AddAffiliatePublisherManagementServices();
builder.AddAffiliatePublisherGroupManagermentServices();
builder.AddSupportTicketExtension();
builder.AddCommonTicketExtension();
builder.AddCommonHistoryExtension();
builder.AddEmailSenderDefault();
builder.AddSignalrSupportTicketExtension();
builder.AddForumExtension();
builder.AddFBBulkPostingExtension();
builder.AddSignalrBulkPostExtension();

//Builder build
var app = builder.Build();
app.AddAppConfigure();
app.AddSocialConfigure();
app.AddLocalizationConfigure();
app.AddForumConfigure();

app.UseExceptionHandler(new ExceptionHandlerOptions()
{
    AllowStatusCode404Response = true,
});

//Add Route
app.AddRegisterRoutes();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = CustomHealthCheckResponseWriter.WriteResponse
});

//Run app
app.Run();

