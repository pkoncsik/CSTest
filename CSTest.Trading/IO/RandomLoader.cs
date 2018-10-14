using System;
using System.Threading;
using CSTest.Shared.Interfaces;
using CSTest.Shared.Model;

namespace CSTest.Trading.IO
{
    public class RandomLoader : ILoader
    {
        private readonly Random _rnd = new Random();

        #region Implementation of ILoader 

        public Trade GetNext()
        {
            var db = 100*_rnd.NextDouble();
            var waiter = _rnd.Next(100);
            Thread.Sleep(waiter);
            var trade = new Trade {Price = db, Moniker = "Test"};
            return trade;
        }

        #endregion
    }
}