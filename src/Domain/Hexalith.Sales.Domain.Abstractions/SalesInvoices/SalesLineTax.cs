namespace Hexalith.Sales.Domain.SalesInvoices;

using System.Runtime.Serialization;

/// <summary>
/// Sales line tax record.
/// </summary>
[DataContract]
public record SalesLineTax(
    [property:DataMember(Order = 1)]
    string TaxId,
    [property:DataMember(Order = 2)]
    string Name,
    [property:DataMember(Order = 3)]
    decimal Amount)
{
}