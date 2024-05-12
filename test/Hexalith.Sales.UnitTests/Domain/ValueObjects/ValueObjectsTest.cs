// <copyright file="ValueObjectsTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Sales.UnitTests.Domain.ValueObjects;

using FluentAssertions;

public class ValueObjectsTest
{
    [Fact]
    public void SalesLineItemShouldBeDataContractSerializable()
        => DummySalesDomainHelper.DummySalesLineItem().Should().BeDataContractSerializable();

    [Fact]
    public void SalesLineOriginShouldBeDataContractSerializable()
        => DummySalesDomainHelper.DummySalesLineOrigin().Should().BeDataContractSerializable();

    [Fact]
    public void SalesLineShouldBeDataContractSerializable()
        => DummySalesDomainHelper.DummySalesLine().Should().BeDataContractSerializable();

    [Fact]
    public void SalesTaxShouldBeDataContractSerializable()
        => DummySalesDomainHelper.DummyTax().Should().BeDataContractSerializable();
}