using NServiceBus;
using System;

namespace Shared
{
    public class OrderSubmitted : IEvent
    {
        public Guid OrderId { get; set; }
        public decimal Value { get; set; }
    }
}
