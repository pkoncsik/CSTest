using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CSTest.Shared.UIHelper;

namespace CSTest.Shared.Model
{
    public class GridModel

    {
        private readonly Random _rnd = new Random();
        public volatile bool StopFlag = false;

        public GridModel()


        {
            Trades.Add(new Trade {Moniker = "IBMBMB", Price = 2323.23});
            Trades.Add(new Trade {Moniker = "srt", Price = 787});
            Trades.Add(new Trade {Moniker = "IBMertBMB", Price = 234});
            Trades.Add(new Trade {Moniker = "sdg", Price = 23.23});
            Task.Factory.StartNew(TradeUpdater);
        }

        public ObservableCollection<Trade> Trades { get; set; } = new ObservableCollection<Trade>();

        public void AddTrade(Trade trade)

        {
            Trades.Add(trade);
        }

        public void RemoveTrade(Trade trade)

        {
            Trades.Remove(trade);
        }

        private void TradeUpdater()

        {
            while (!StopFlag)

            {
                Execute.OnUiThread(UpdateTradeList);
                Thread.Sleep(100);
            }
        }

        private void UpdateTradeList()

        {
            var count = Trades.Count;
            var removeId = _rnd.Next(count);
            var testprice = _rnd.Next(100);
            Trades[removeId].Price = testprice;
        }
    }
}