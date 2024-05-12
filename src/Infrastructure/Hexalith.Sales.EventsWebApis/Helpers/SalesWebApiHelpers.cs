namespace Hexalith.Sales.EventsWebApis.Helpers;

using System.Diagnostics.CodeAnalysis;

using Hexalith.Application.Projections;
using Hexalith.Infrastructure.DaprRuntime.Helpers;
using Hexalith.Sales.Domain.SalesInvoices;
using Hexalith.Sales.Events.SalesInvoices;
using Hexalith.Sales.EventsWebApis.Controllers;
using Hexalith.Sales.EventsWebApis.Projections;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Sales web api helpers.
/// </summary>
public static class SalesWebApiHelpers
{
    /// <summary>
    /// Adds the customer projections.
    /// </summary>
    /// <param name="services">The services collection.</param>
    /// <param name="applicationId">The application identifier.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="ArgumentNullException">Service is null.</exception>
    /// <exception cref="ArgumentException">Application identifier is empty.</exception>
    public static IServiceCollection AddSalesInvoiceProjections([NotNull] this IServiceCollection services, [NotNull] string applicationId)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationId);
        services.TryAddScoped<IProjectionUpdateHandler<SalesInvoiceIssued>, SalesInvoiceIssuedProjectionUpdateHandler>();
        _ = services.AddActorProjectionFactory<SalesInvoice>(applicationId);
        _ = services
         .AddControllers()
         .AddApplicationPart(typeof(SalesInvoiceIntegrationEventsController).Assembly)
         .AddDapr();
        return services;
    }
}