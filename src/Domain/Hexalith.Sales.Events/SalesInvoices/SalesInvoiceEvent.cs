// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 08-21-2023
// ***********************************************************************
// <copyright file="SalesInvoiceEvent.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.Events.SalesInvoices;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;
using Hexalith.Extensions;
using Hexalith.Sales.Domain.Helpers;

/// <summary>
/// Class SalesInvoiceEvent.
/// Implements the <see cref="CompanyEntityEvent" />.
/// </summary>
/// <seealso cref="CompanyEntityEvent" />
[DataContract]
public class SalesInvoiceEvent : CompanyEntityEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceEvent"/> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected SalesInvoiceEvent(string partitionId, string companyId, string originId, string id)
        : base(partitionId, companyId, originId, id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceEvent" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected SalesInvoiceEvent()
    {
    }

    /// <inheritdoc/>
    protected override string DefaultAggregateId()
        => SalesDomainHelper.GetSalesInvoiceAggregateId(PartitionId, CompanyId, OriginId, Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName()
        => SalesDomainHelper.SalesInvoiceAggregateName;
}