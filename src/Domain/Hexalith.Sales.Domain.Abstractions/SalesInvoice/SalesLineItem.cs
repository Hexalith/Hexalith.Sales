namespace Hexalith.Sales.Domain.SalesInvoice;

using System.Runtime.Serialization;

/// <summary>
/// Sales line item record.
/// </summary>
[DataContract]
public record SalesLineItem(
    [property: DataMember(Order = 1)] string ItemId,
    [property: DataMember(Order = 2)] decimal Quantity,
    [property: DataMember(Order = 3)] string UnitId,
    [property: DataMember(Order = 4)] decimal Price)
{
}