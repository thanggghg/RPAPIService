using RP.API.Routes;
using RP.Commissions.Extensions;
using RP.CommonHistory.Extensions;
using RP.CommonTicket.Extensions;
using RP.EmailSender.Extensions;
using RP.EWarranty.Extensions;
using RP.Exports.Extensions;
using RP.FBBulkPosting.Extension;
using RP.Forum.Extensions;
using RP.Library.Extensions.Localization;
using RP.Orders.Extension;
using RP.Payments.Extension;
using RP.SupportTicket.Extension;
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

