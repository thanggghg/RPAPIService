using GoSell.API.Routes.AffiliatePublisherGroupManagement;
using GoSell.API.Routes.AffiliatePublisherManagement;
using GoSell.API.Routes.AffliateTracking;
using GoSell.API.Routes.Analysis;
using GoSell.API.Routes.Comments;
using GoSell.API.Routes.Commission;
using GoSell.API.Routes.CommissionPayments;
using GoSell.API.Routes.CommonHistory;
using GoSell.API.Routes.CommonTicket;
using GoSell.API.Routes.Exports;
using GoSell.API.Routes.FBBulkPosting;
using GoSell.API.Routes.Forums;
using GoSell.API.Routes.Getaways;
using GoSell.API.Routes.MposDevices;
using GoSell.API.Routes.Orders;
using GoSell.API.Routes.Payments;
using GoSell.API.Routes.SigninAffiliate;
using GoSell.API.Routes.SocialSignin;
using GoSell.API.Routes.SupportTicket;
using GoSell.API.Routes.Warranties;
using GoSell.Library.Extensions.JWT;
using GoSell.Library.Utils;
using GoSell.Ordering.API.Extensions;

namespace GoSell.API.Routes
{
    public static class ApiRouting
    {
        public static RouteHandlerBuilder AddRequireAuthorizationJWTToken(this RouteHandlerBuilder builder, string Policy = "")
        {
            return builder.RequireAuthorization(String.IsNullOrEmpty(Policy) ? AuthoritiesConstants.DEFAULT : Policy);
        }
        public static RouteHandlerBuilder AddStaffPermissionRequirementHandle(this RouteHandlerBuilder builder, string Policy = "")
        {
            return builder.RequireAuthorization(Policy);
        }
        public static IEndpointConventionBuilder AddRequireAuthorizationJWTToken(this IEndpointConventionBuilder builder, string Policy = "")
        {
            return builder.RequireAuthorization(String.IsNullOrEmpty(Policy) ? AuthoritiesConstants.DEFAULT : Policy);
        }
        public static void AddRegisterRoutes(this WebApplication app)
        {
            app.RegisterDefault();
            app.RegisterConnect();
            app.RegisterOrders();
            app.RegisterAnalysis();
            app.RegisterSocial();
            app.RegisterPayments();
            app.RegisterMpos();
            app.RegisterWarranties();
            app.RegisterComments();
            app.RegisterCommission();
            app.RegisterMapMultiTier();
            app.RegisterExport();
            app.RegisterAffiliateTracking();
            app.RegisterAffiliateAuthencation();
            app.RegisterAffiliateProduct();
            app.RegisterAffiliateCampaign();
            app.RegisterSupportTicket();
            app.RegisterAffiliatePublisherManagement();
            app.RegisterAffiliateCategory();
            app.RegisterCommonTicket();
            app.RegisterAffiliatePublisherGroupManagement();
            app.RegisterAffiliateCommissionPayments();
            app.RegisterCommonHistory();
            app.RegisterAffiliateReport();
            app.RegisterCommissionBonus();
            app.RegisterForums();
            app.RegisterFBBulkPosting();
            app.RegisterGetaway();
        }
        public static void RegisterDefault(this WebApplication app)
        {

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync($"Welcome Go Sell .NET! Version: {typeof(GoSell.API.Routes.ApiRouting).Assembly.GetName().Version}");
            });
        }
        public static void RegisterConnect(this WebApplication app)
        {
            app.MapPost("/connect/token", async (HttpContext ctx, JwtOptions jwtOptions)
                => await TokenEndpoint.Connect(ctx, jwtOptions));
        }
        public static void RegisterSocial(this WebApplication app)
        {
            app.MapGroup("/api/signin")
               .MapSocialSigninRouting();
        }

        public static void RegisterGetaway(this WebApplication app)
        {
            app.MapGroup("/api/v1/getaway")
               .MapGetawayRouting();
        }

        public static void RegisterOrders(this WebApplication app)
        {
            app.MapGroup("/api/v1/orders")
               .MapOrdersApi();
        }
        public static void RegisterAnalysis(this WebApplication app)
        {
            app.MapGroup("/api/v1/analysis")
              .MapAnalysisApi();
        }
        public static void RegisterPayments(this WebApplication app)
        {
            app.MapGroup("/api/v1/payments")
               .MapPaymentsApi();
        }
        public static void RegisterMpos(this WebApplication app)
        {
            app.MapGroup("/api/v1/mpos")
               .MapMposDevicesApi();
        }
        public static void RegisterWarranties(this WebApplication app)
        {
            app.MapGroup("/api/v1/warranties")
               .MapWarrantyApis();
        }
        public static void RegisterComments(this WebApplication app)
        {
            app.MapGroup("/api/v1/comments")
             .MapCommentsApi();
        }
        public static void RegisterCommission(this WebApplication app)
        {
            app.MapGroup("/api/v1/commission")
             .MapCommissionApi();
        }
        public static void RegisterMapMultiTier(this WebApplication app)
        {
            app.MapGroup("/api/v1/multi-tier")
             .MapMultiTierApi();
        }
        public static void RegisterFiles(this WebApplication app)
        {
            app.MapGroup("/api/v1/files")
             .MapFilesApi();
        }
        public static void RegisterExport(this WebApplication app)
        {
            app.MapGroup("/api/v1/export")
               .MapExportRouting();
        }
        public static void RegisterAffiliateTracking(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate")
               .MapAffiliateTrackingApi();
        }
        public static void RegisterAffiliateAuthencation(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/authentication")
               .MapAffiliateAuthencationApi();
        }
        public static void RegisterAffiliateProduct(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/product")
               .MapAffiliateProductApi();
        }
        public static void RegisterAffiliateCampaign(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/campaign")
               .MapAffiliateCampaignApi();
        }
        public static void RegisterSupportTicket(this WebApplication app)
        {
            app.MapGroup("/api/v1/support-ticket")
               .MapSupportTicketsApi();
        }
        public static void RegisterAffiliatePublisherManagement(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate")
               .MapAffiliatePublisherManagementApi();
        }
        public static void RegisterAffiliateCategory(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/category")
               .MapAffiliateCategoryApi();
        }
        public static void RegisterCommonTicket(this WebApplication app)
        {
            app.MapGroup("/api/v1/common-ticket")
               .MapCommonTicketsApi();
        }
        public static void RegisterAffiliatePublisherGroupManagement(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/group")
               .MapAffiliatePublisherGroupManagementApi();
        }

        public static void RegisterAffiliateCommissionPayments(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/commission-payment")
               .MapCommissionPaymentsApi();
        }

        public static void RegisterCommonHistory(this WebApplication app)
        {
            app.MapGroup("/api/v1/common-history")
               .MapCommonHistoryApi();
        }

        public static void RegisterAffiliateReport(this WebApplication app)
        {
            app.MapGroup("/api/v1/affiliate/report")
               .MapAffiliateReportApi();
        }

        public static void RegisterCommissionBonus(this WebApplication app)
        {
            app.MapGroup("/api/v1/bonus")
             .MapBonusApi();
        }

        public static void RegisterForums(this WebApplication app)
        {
            app.MapGroup("/api/v1/forum")
               .MapForumCategoryRoutingApis()
               .MapForumTopicRoutingApis()
               .MapForumPostRoutingApis()
               .MapForumConfigurationRoutingApis()
               .MapSEOSettingRoutingApis()
               .MapForumStoreFrontRoutingApis()
               .MapForumCommentsRoutingApis()
               .MapForumMembersRoutingApis()
               .MapForumPaymentPackageApis();
        }

        public static void RegisterFBBulkPosting(this WebApplication app)
        {
            app.MapGroup("/api/v1/fb-bulk-posting")
             .MapFBBulkPostingApi();
        }
    }
}
