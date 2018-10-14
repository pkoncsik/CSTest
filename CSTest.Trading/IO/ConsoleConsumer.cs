using System;
using System.Threading;
using CSTest.Shared.Interfaces;
using CSTest.Shared.Model;

namespace CSTest.Trading.IO
{
    public class ConsoleConsumer : IConsumer
    {
        private readonly Random _rnd = new Random();

        #region Implementation of IConsumer 

        public void ReadNext(Trade trade)
        {
            var waiter = _rnd.Next(1000);
            Thread.Sleep(waiter);
            Console.WriteLine(trade);
        }

        #endregion
    }
}