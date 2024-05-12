// ***********************************************************************
// Assembly         : Hexalith.Domain.Sales
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 08-21-2023
// ***********************************************************************
// <copyright file="SalesInvoiceCommand.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.Commands.SalesInvoice;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Application.Commands;
using Hexalith.Domain.Events;
using Hexalith.Extensions;
using Hexalith.Sales.Domain.Helpers;

/// <summary>
/// Class SalesInvoiceEvent.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DataContract]
public class SalesInvoiceCommand : CompanyEntityCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceCommand"/> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected SalesInvoiceCommand(
        string partitionId,
        string companyId,
        string originId,
        string id)
        : base(partitionId, companyId, originId, id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceCommand" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected SalesInvoiceCommand()
    {
    }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => SalesDomainHelper.GetSalesInvoiceAggregateId(PartitionId, CompanyId, OriginId, Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => SalesDomainHelper.SalesInvoiceAggregateName;
}