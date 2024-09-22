using System.ComponentModel;

namespace RP.Affiliate.Tracking.Commons.Enums
{
    public enum CampaignResponseCodeEnum
    {
        [Description("Campaign not exist")]
        CampaignNotExist = 0,

        [Description("Campaign name is required")]
        CampaignNameIsRequired = 1,

        [Description("This campaign name is existed")]
        ExitedCampaignName = 2,

        [Description("Start time must be at least 5 minutes from the current time")]
        StartDate5Minutes = 3,

        [Description("Applied time of campaign is not valid")]
        AppliedTimeOfCampaignInValid = 4,

        [Description("Campaign needs to last at least 1 hour and not exceed 30 days")]
        StartDateEndDateLeast1Hour30Day = 5,    

        [Description("Please add product in this campaign")]
        AddProductToCampaign = 6,

        [Description("Campaign contains product(s) which be deleted or stop selling. Please check again!")]
        InValidProductInCampaign = 7,

        [Description("The applied time overlaps with other campaign(s). Please check again!")]
        OverlapOtherCampaign = 8,

        [Description("Not found affiliate store")]
        NotFoundAffiliateStore = 9,

        [Description("Can not change campaign has status is not DRAFT or PUBLISHED")]
        StatusNotChange = 10,

        [Description("Product list has invalid items")]
        ProductListError = 11,

        [Description("Oops! There was a problem, please try again!")]
        SaveDataIntoDBError = 12,

        [Description("Cannot terminate! This campaign is ended. Please reload this page!")]
        EndedCampaign = 13,

        [Description("Outdated data")]
        OutdatedData = 14,

        [Description("Save successfully")]
        SaveSuccessfully = 200,
    }
}
