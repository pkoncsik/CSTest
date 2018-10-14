using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSTest.Shared.Interfaces;
using CSTest.Shared.Model;

namespace CSTest.Trading.Processing
{
    public class TradeProcessor
    {
        private readonly IQueue<Trade> _queue;
        private readonly IConsumer _consumer;
        private volatile bool _shouldStop;


        public TradeProcessor(IQueue<Trade> queue, IConsumer consumer)
        {
            _queue = queue;
            _consumer = consumer;
        }

        private void Process()
        {
            while (! _shouldStop)
            {
                var trade = _queue.DeQueue();


                if (trade == null)

                {
                    Console.WriteLine("Waiting for trades ... ");
                    Thread.Sleep(500);
                }
                _consumer.ReadNext(trade);
            }
        }

        public void Stop()
        {
            _shouldStop = true;
        }

        public void Start()
        {
            _shouldStop = false;
            Task.Factory.StartNew(Process);
        }
    }
}