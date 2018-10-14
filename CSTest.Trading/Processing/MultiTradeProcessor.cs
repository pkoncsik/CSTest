using System.Collections.Generic;
using CSTest.Shared.Interfaces;
using CSTest.Shared.Model;

namespace CSTest.Trading.Processing
{
    public class MultiTradeProcessor
    {
        private readonly List<TradeProcessor> _processors = new List<TradeProcessor>();

        public MultiTradeProcessor(IQueue<Trade> queue,
            IEnumerable<IConsumer> consumers)

        {
            foreach (var consumer in consumers)
            {
                _processors.Add(new TradeProcessor(queue, consumer));
            }
        }

//Excoption!
        public void Stop()
        {
            _processors.ForEach(t => t.Stop());
        }

//Exceptionhandling in loop!
        public void Start()
        {
            _processors.ForEach(t => t.Start());
        }
    }
}