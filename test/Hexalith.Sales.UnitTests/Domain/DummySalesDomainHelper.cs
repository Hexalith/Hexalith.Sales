// <copyright file="DummySalesDomainHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Sales.UnitTests.Domain;

using Hexalith.Sales.Domain.SalesInvoices;
using Hexalith.Sales.Events.SalesInvoices;

public static class DummySalesDomainHelper
{
    public static SalesInvoice DummySalesInvoice() => new(DummySalesInvoiceIssued());

    public static SalesInvoiceIssued DummySalesInvoiceIssued()
        => new(
            "PART1",
            "Company1",
            "ORIG1",
            "Inv123456",
            new DateTimeOffset(2002, 11, 5, 10, 6, 25, TimeSpan.Zero),
            "GRP1",
            "YEN",
            [DummySalesDomainHelper.DummySalesLine(), DummySalesLine2()]);

    public static SalesInvoiceLine DummySalesLine()
        => new("Line1", DummySalesLineItem(), DummySalesLineOrigin(), [DummyTax()]);

    public static SalesInvoiceLine DummySalesLine2()
        => new("Line1", DummySalesLineItem2(), DummySalesLineOrigin(), [DummyTax()]);

    public static SalesLineItem DummySalesLineItem()
        => new("Item123", 10m, "L", 0.20m);

    public static SalesLineItem DummySalesLineItem2()
        => new("Item1234", 1m, "Unit", 2.50m);

    public static SalesLineOrigin DummySalesLineOrigin()
        => new("Location123", "Vendor123");

    public static SalesLineTax DummyTax()
                => new("Vat20", "Normal Tax", 0.20m);
}