﻿// <copyright file="SalesLineItemTest - Copy.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.UnitTests.Core.Domain.Sales.ValueObjects;

using Hexalith.TestMocks;

public class SalesLineTaxTest : SerializationTestBase
{
    public override object ToSerializeObject() => DummySalesDomainHelper.DummySalesLineTax();
}