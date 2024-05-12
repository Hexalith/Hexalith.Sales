namespace Hexalith.Sales.Domain.SalesInvoice;

using System.Runtime.Serialization;

/// <summary>
/// Sales line origin record.
/// </summary>
[DataContract]
public record SalesLineOrigin(
    [property:DataMember(Order = 1)]
    string LocationId,
    [property:DataMember(Order = 2)]
    string VendorId)
{
}