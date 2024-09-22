namespace GoSell.API.Requests
{
    public record CreateAffiliateLinkRequest(long CampaignId,
                                             List<string> OriginLinks,
                                             string SubId1,
                                             string SubId2,
                                             string SubId3,
                                             string SubId4,
                                             string SubId5);
    public record AffiliateStoreRequest(long Id,
                                        long GoSellStoreId,
                                        string Logo,
                                        string Name,
                                        string ApiKey,
                                        string Website,
                                        bool AllowPublisherRegister,
                                        bool AutoApproved,
                                        long BusinessId,
                                        long ColorId,
                                        bool AllowGetOrderTrackingUrl,
                                        string KeyWordByUrl,
                                        bool AllowGetOrderTrackingCode,
                                        string KeyWordByCode,
                                        long? CurrencyId,
                                        int CookieDurationDay = 5);

    public record AffiliateStatusOrderAsync(List<string> OriginLinks, int Status);
}
