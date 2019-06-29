using NsbSamplesSqlOutbox.DatabaseSpecific;
using NsbSamplesSqlOutbox.EntityClasses;
using NServiceBus;
using NServiceBus.Logging;
using Shared;
using System.Threading.Tasks;

namespace Receiver
{
    public class OrderSubmittedHandler :
        IHandleMessages<OrderSubmitted>
    {
        static ILog log = LogManager.GetLogger<OrderSubmittedHandler>();

        public async Task Handle(OrderSubmitted message, IMessageHandlerContext context)
        {
            log.Info($"Order {message.OrderId} worth {message.Value} submitted");

            #region StoreUserData

            var session = context.SynchronizedStorageSession.SqlPersistenceSession();

            using (var adapter = new DataAccessAdapter(session.Connection.ConnectionString))
            {
                await adapter.StartTransactionAsync(session.Transaction.IsolationLevel, ToString()).ConfigureAwait(false);
                await adapter.SaveEntityAsync(new SubmittedOrderEntity
                {
                    Id = message.OrderId,
                    Value = (int)message.Value,
                }).ConfigureAwait(false);
            }

            #endregion

            #region Reply

            var orderAccepted = new OrderAccepted
            {
                OrderId = message.OrderId,
            };
            await context.Reply(orderAccepted)
                .ConfigureAwait(false);

            #endregion
        }

    }
}
