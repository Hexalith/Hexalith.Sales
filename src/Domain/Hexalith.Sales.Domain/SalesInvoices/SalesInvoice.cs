// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 08-29-2023
// ***********************************************************************
// <copyright file="SalesInvoice.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.Domain.SalesInvoices;

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;
using Hexalith.Sales.Domain.Helpers;
using Hexalith.Sales.Events.SalesInvoices;

/// <summary>
/// Class SalesInvoice.
/// Implements the <see cref="Aggregate" />
/// Implements the <see cref="IAggregate" />.
/// </summary>
/// <seealso cref="Aggregate" />
/// <seealso cref="IAggregate" />
[DataContract]
public record SalesInvoice(
    string PartitionId,
    string CompanyId,
    string OriginId,
    string Id,
    [property: DataMember(Order = 10)] DateTimeOffset? CreatedDate,
    [property: DataMember(Order = 11)] string? CustomerId,
    [property: DataMember(Order = 12)] string? CurrencyId,
    [property: DataMember(Order = 20)] IEnumerable<SalesInvoiceLine> Lines)
    : EntityAggregate(PartitionId, CompanyId, OriginId, Id)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoice"/> class.
    /// </summary>
    public SalesInvoice()
       : this(
              string.Empty,
              string.Empty,
              string.Empty,
              string.Empty,
              null,
              null,
              null,
              [])
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoice"/> class.
    /// </summary>
    /// <param name="issued">The issued.</param>
    public SalesInvoice(SalesInvoiceIssued issued)
       : this(
              (issued ?? throw new ArgumentNullException(nameof(issued))).PartitionId,
              issued.CompanyId,
              issued.OriginId,
              issued.Id,
              issued.CreatedDate,
              issued.CustomerId,
              issued.CurrencyId,
              issued.Lines.ToImmutableList())
    {
    }

    /// <inheritdoc/>
    public override (IAggregate Aggregate, IEnumerable<BaseEvent> Events) Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        if (domainEvent is SalesInvoiceIssued issued)
        {
            return IsInitialized()
                ? throw new InvalidAggregateEventException(this, domainEvent, true)
                : ((IAggregate Aggregate, IEnumerable<BaseEvent> Events))(new SalesInvoice(issued), [domainEvent]);
        }

        throw new InvalidAggregateEventException(this, domainEvent, false);
    }

    /// <inheritdoc/>
    public override bool IsInitialized() => !string.IsNullOrEmpty(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => SalesDomainHelper.GetSalesInvoiceAggregateId(PartitionId, CompanyId, OriginId, Id);
}