namespace Hexalith.Sales.EventsWebApis.Projections;

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Application.Metadatas;
using Hexalith.Infrastructure.DaprRuntime.Projections;
using Hexalith.Sales.Domain.SalesInvoice;
using Hexalith.Sales.Events.SalesInvoice;

/// <summary>
/// Sales invoice projection update handler base class.
/// Implements the <see cref="Hexalith.Infrastructure.DaprRuntime.Projections.KeyValueActorProjectionUpdateEventHandlerBase{TSalesInvoiceEvent, Hexalith.Sales.Domain.SalesInvoice.SalesInvoice}" />.
/// </summary>
/// <typeparam name="TSalesInvoiceEvent">The type of the t sales invoice event.</typeparam>
/// <seealso cref="Hexalith.Infrastructure.DaprRuntime.Projections.KeyValueActorProjectionUpdateEventHandlerBase{TSalesInvoiceEvent, Hexalith.Sales.Domain.SalesInvoice.SalesInvoice}" />
public class SalesInvoiceProjectionUpdateHandler<TSalesInvoiceEvent> : KeyValueActorProjectionUpdateEventHandlerBase<TSalesInvoiceEvent, SalesInvoice>
    where TSalesInvoiceEvent : SalesInvoiceEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceProjectionUpdateHandler{T}"/> class.
    /// </summary>
    /// <param name="factory">The actor projection factory.</param>
    protected SalesInvoiceProjectionUpdateHandler(IActorProjectionFactory<SalesInvoice> factory)
        : base(factory)
    {
    }

    /// <inheritdoc/>
    public override async Task ApplyAsync([NotNull] TSalesInvoiceEvent baseEvent, IMetadata metadata, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(baseEvent);
        if (baseEvent is SalesInvoiceIssued issued)
        {
            await SaveProjectionAsync(baseEvent.AggregateId, new SalesInvoice(issued), cancellationToken).ConfigureAwait(false);
        }
    }
}