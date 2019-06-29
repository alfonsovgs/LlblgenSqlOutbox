using NServiceBus;
using System;

namespace Shared
{
    public class OrderAccepted : IMessage
    {
        public Guid OrderId { get; set; }
    }
}
