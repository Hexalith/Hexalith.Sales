namespace Hexalith.Sales.Domain.Helpers;

using System.Diagnostics.CodeAnalysis;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Sales Domain helper.
/// </summary>
public static class SalesDomainHelper
{
    /// <summary>
    /// Gets the separator character used in the sales invoice aggregate ID.
    /// </summary>
    public static char IdSeparator => '-';

    /// <summary>
    /// Gets the name of the sales invoice aggregate.
    /// </summary>
    public static string SalesInvoiceAggregateName => "SalesInvoice";

    /// <summary>
    /// Gets the sales invoice aggregate ID.
    /// </summary>
    /// <param name="partitionId">The partition ID.</param>
    /// <param name="companyId">The company ID.</param>
    /// <param name="originId">The origin ID.</param>
    /// <param name="id">The ID.</param>
    /// <returns>The sales invoice aggregate ID.</returns>
    public static string GetSalesInvoiceAggregateId([NotNull] string partitionId, [NotNull] string companyId, [NotNull] string originId, [NotNull] string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(partitionId);
        ArgumentException.ThrowIfNullOrWhiteSpace(companyId);
        ArgumentException.ThrowIfNullOrWhiteSpace(originId);
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        return Aggregate.Normalize(SalesInvoiceAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + originId + IdSeparator + id);
    }
}