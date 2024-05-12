// ***********************************************************************
// Assembly         : Hexalith.UnitTests
// Author           : Jérôme Piquot
// Created          : 12-07-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-07-2023
// ***********************************************************************
// <copyright file="IssueSalesInvoiceTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Sales.UnitTests.Application.Commands;

using FluentAssertions;

using Hexalith.Application.Commands;
using Hexalith.Sales.Commands.SalesInvoice;
using Hexalith.TestMocks;

/// <summary>
/// Class IssueSalesInvoiceTest.
/// Implements the <see cref="PolymorphicSerializationTestBase{Hexalith.Application.Sales.Commands.IssueSalesInvoice, BaseCommand}" />.
/// </summary>
/// <seealso cref="PolymorphicSerializationTestBase{Hexalith.Application.Sales.Commands.IssueSalesInvoice, BaseCommand}" />
public class IssueSalesInvoiceTest : PolymorphicSerializationTestBase<IssueSalesInvoice, BaseCommand>
{
    /// <summary>
    /// Defines the test method IssueSalesInvoiceCheckAggregateId.
    /// </summary>
    [Fact]
    public void IssueSalesInvoiceCheckAggregateId()
    {
        IssueSalesInvoice e = DummySalesApplicationHelper
            .DummyIssueSalesInvoice();
        _ = e.AggregateId.Should().Be("SalesInvoice-PART1-Company1-ORIG1-Inv123456");
    }

    /// <summary>
    /// Converts to serialize object.
    /// </summary>
    /// <returns>System.Object.</returns>
    public override object ToSerializeObject() => DummySalesApplicationHelper.DummyIssueSalesInvoice();
}