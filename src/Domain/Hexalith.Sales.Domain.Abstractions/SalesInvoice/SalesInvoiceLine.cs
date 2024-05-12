// ***********************************************************************
// Assembly         : Hexalith.Domain.Sales
// Author           : Jérôme Piquot
// Created          : 01-02-2024
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 01-03-2024
// ***********************************************************************
// <copyright file="SalesInvoiceLine.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.Sales.Domain.SalesInvoice;

using System.Runtime.Serialization;

/// <summary>
/// Class SalesLineItem.
/// </summary>
[DataContract]
public record SalesInvoiceLine(
    [property: DataMember(Order = 1)] string Id,
    [property: DataMember(Order = 2)] SalesLineItem Item,
    [property: DataMember(Order = 3)] SalesLineOrigin Origin,
    [property: DataMember(Order = 10)] IEnumerable<SalesLineTax> Taxes)
{
}