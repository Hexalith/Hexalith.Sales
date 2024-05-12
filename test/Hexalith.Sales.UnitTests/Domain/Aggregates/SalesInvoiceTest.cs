namespace Hexalith.Sales.UnitTests.Domain.Aggregates;

using FluentAssertions;

using Hexalith.Sales.Domain.SalesInvoices;
using Hexalith.TestMocks;

public class SalesInvoiceTest : SerializationTestBase
{
    [Fact]
    public void SalesInvoiceCheckAggregateId()
    {
        SalesInvoice c = DummySalesDomainHelper.DummySalesInvoice();
        _ = c.AggregateId.Should().Be("SalesInvoice-PART1-Company1-ORIG1-Inv123456");
    }

    public override object ToSerializeObject() => DummySalesDomainHelper.DummySalesInvoice();
}