using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSTest.Shared.Interfaces;
using CSTest.Shared.Model;

namespace CSTest.Trading.Model
{
    public class TradeQueue : IQueue<Trade>
    {
        private readonly BlockingCollection<Trade> _innerqueue = new BlockingCollection<Trade>(512);

        public void Queue(Trade trade)
        {
            _innerqueue.Add(trade);
        }

        public Trade DeQueue()
        {
            Trade trade;
            _innerqueue.TryTake(out trade, 100);
            return trade;
        }
    }
}