﻿// ***********************************************************************
// Assembly         : Hexalith.Application.Sales
// Author           : Jérôme Piquot
// Created          : 08-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-21-2023
// ***********************************************************************
// <copyright file="RegisterSalesInvoiceHandler.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.Application.SalesInvoices.CommandHandlers;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Application.Commands;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Messages;
using Hexalith.Sales.Commands.SalesInvoices;
using Hexalith.Sales.Domain.SalesInvoices;
using Hexalith.Sales.Events.SalesInvoices;

using Microsoft.Extensions.Logging;

/// <summary>
/// Class RegisterSalesInvoiceHandler.
/// Implements the <see cref="Application.Commands.CommandHandler{Commands.IssueSalesInvoice}" />.
/// </summary>
/// <seealso cref="Application.Commands.CommandHandler{Commands.IssueSalesInvoice}" />
public class IssueSalesInvoiceHandler : CommandHandler<IssueSalesInvoice>
{
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<IssueSalesInvoiceHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueSalesInvoiceHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public IssueSalesInvoiceHandler(ILogger<IssueSalesInvoiceHandler> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> DoAsync([NotNull] IssueSalesInvoice command, IAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        SalesInvoice salesInvoice = aggregate as SalesInvoice ?? new SalesInvoice();
        SalesInvoiceIssued issued =
            new(
                command.PartitionId,
                command.CompanyId,
                command.OriginId,
                command.Id,
                command.CreatedDate,
                command.CurrencyId,
                command.CustomerId,
                command.Lines);
        _ = salesInvoice.Apply(issued);
        return await Task.FromResult((IEnumerable<BaseMessage>)[issued])
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> UndoAsync(IssueSalesInvoice command, IAggregate? aggregate, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        throw new NotSupportedException();
    }
}