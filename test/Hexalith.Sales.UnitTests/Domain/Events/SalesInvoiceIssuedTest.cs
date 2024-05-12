// <copyright file="SalesInvoiceIssuedTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Sales.UnitTests.Domain.Events;

using FluentAssertions;

using Hexalith.Domain.Events;
using Hexalith.Sales.Events.SalesInvoice;
using Hexalith.TestMocks;

public class SalesInvoiceIssuedTest : PolymorphicSerializationTestBase<SalesInvoiceIssued, BaseEvent>
{
    [Fact]
    public void SalesInvoiceIssuedCheckAggregateId()
    {
        SalesInvoiceIssued e = DummySalesDomainHelper
            .DummySalesInvoiceIssued();
        _ = e.AggregateId.Should().Be("SalesInvoice-PART1-Company1-ORIG1-Inv123456");
    }

    public override object ToSerializeObject() => DummySalesDomainHelper.DummySalesInvoiceIssued();
}