namespace Hexalith.Sales.UnitTests.Application;

using Hexalith.Sales.Commands.SalesInvoices;
using Hexalith.Sales.UnitTests.Domain;

public static class DummySalesApplicationHelper
{
    public static IssueSalesInvoice DummyIssueSalesInvoice()
         => new(
            "PART1",
            "Company1",
            "ORIG1",
            "Inv123456",
            new DateTimeOffset(2002, 11, 5, 10, 6, 25, TimeSpan.Zero),
            "GRP1",
            "YEN",
            [DummySalesDomainHelper.DummySalesLine(), DummySalesDomainHelper.DummySalesLine2()]);
}