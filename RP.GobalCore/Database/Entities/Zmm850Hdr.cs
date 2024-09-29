using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Hdr
{
    public int HdrPk { get; set; }

    public string Partner { get; set; }

    public string Beg03PoNumber { get; set; }

    public DateTime? Hdr850Processed { get; set; }

    public string Beg01HdrPoPurposeCode { get; set; }

    public string Beg02HdrPoTypeCd { get; set; }

    public string Beg04ReleaseNumber { get; set; }

    public DateTime? Beg05HdrPoDate { get; set; }

    public string Beg06ContractNumber { get; set; }

    public string Cur01EntityCd { get; set; }

    public string Cur02CurrencyCd { get; set; }

    public DateTime? Dtm02PromotionStart { get; set; }

    public string Dtm03PromotionStart { get; set; }

    public DateTime? Dtm02CancelAfter { get; set; }

    public string Dtm03CancelAfter { get; set; }

    public DateTime? Dtm02DeliveryRequested { get; set; }

    public string Dtm03DeliveryRequested { get; set; }

    public DateTime? Dtm02EffectiveDate { get; set; }

    public string Dtm03EffectiveDate { get; set; }

    public DateTime? Dtm02RequestedShip { get; set; }

    public string Dtm03RequestedShip { get; set; }

    public DateTime? Dtm02ShipNotBefore { get; set; }

    public string Dtm03ShipNotBefore { get; set; }

    public DateTime? Dtm02ShipNoLater { get; set; }

    public string Dtm03ShipNoLater { get; set; }

    public DateTime? Dtm02DoNotDeliverBefore { get; set; }

    public string Dtm03DoNotDeliverBefore { get; set; }

    public DateTime? Dtm02DoNotDeliverAfter { get; set; }

    public string Dtm03DoNotDeliverAfter { get; set; }

    public DateTime? Dtm02PromisedForDelivery { get; set; }

    public string Dtm03PromisedForDelivery { get; set; }

    public DateTime? Dtm02RequestedPickup { get; set; }

    public string Dtm03RequestedPickup { get; set; }

    public string Csh01SalesReqCd1 { get; set; }

    public string Csh01SalesReqCd2 { get; set; }

    public string Csh01SalesReqCd3 { get; set; }

    public string Csh01SalesReqCd4 { get; set; }

    public string Csh01SalesReqCd5 { get; set; }

    public int? Ctt01NumberOfLineItems { get; set; }

    public double? Ctt02HashTotal { get; set; }

    public string Amt01AmountQcd { get; set; }

    public double? Amt02Amount { get; set; }

    public string Comment { get; set; }

    public DateTime? NotificationSent { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
