// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.SalesEvents
// Author           : Jérôme Piquot
// Created          : 11-12-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 11-12-2023
// ***********************************************************************
// <copyright file="SalesInvoiceRegisteredProjectionUpdateHandler.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.EventsWebApis.Projections;

using Hexalith.Infrastructure.DaprRuntime.Projections;
using Hexalith.Sales.Domain.SalesInvoice;
using Hexalith.Sales.Events.SalesInvoice;

/// <summary>
/// Class SalesInvoiceRegisteredProjectionUpdateHandler.
/// Implements the <see cref="Application.Events.IntegrationEventProjectionUpdateHandler{SalesInvoiceRegistered}" />.
/// </summary>
/// <seealso cref="Application.Events.IntegrationEventProjectionUpdateHandler{SalesInvoiceRegistered}" />
public class SalesInvoiceIssuedProjectionUpdateHandler : SalesInvoiceProjectionUpdateHandler<SalesInvoiceIssued>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceIssuedProjectionUpdateHandler"/> class.
    /// </summary>
    /// <param name="factory">The factory.</param>
    /// <param name="logger">The logger.</param>
    public SalesInvoiceIssuedProjectionUpdateHandler(IActorProjectionFactory<SalesInvoice> factory)
        : base(factory)
    {
    }
}