using NServiceBus;
using NServiceBus.Logging;
using Shared;
using System.Threading.Tasks;

namespace Sender
{
    public class OrderAcceptedHandler : IHandleMessages<OrderAccepted>
    {
        private static readonly ILog _log = LogManager.GetLogger<OrderAcceptedHandler>();

        public Task Handle(OrderAccepted message, IMessageHandlerContext context)
        {
            _log.Info($"Order {message.OrderId} accepted.");
            return Task.CompletedTask;
        }
    }
}
