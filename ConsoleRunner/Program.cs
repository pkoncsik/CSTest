using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSTest.Shared.Config;
using CSTest.Shared.Interfaces;
using CSTest.Trading.Model;
using CSTest.Trading.Processing;

namespace ConsoleRunner
{
    internal class Program
    {
        private static volatile bool _flag = true;
        private static void Main(string[] args)
        {
            
            //List<int> tl = new List<int> { 1, 2, 4, 5, 6, 7 }; 
            //tl.ForEach(Test) ;
            var queue = new TradeQueue();

            string tradeLoaderString  = ConfigReader.GetConfig("Plugins").TradeLoader;
            string tradeConsumerString = ConfigReader.GetConfig("Plugins").TradeConsumer;
            var loader = DiLoader.GetType<ILoader>(tradeLoaderString);
            var consumers = new List<IConsumer>();
            for (var i = 0; i < 5; i++) consumers.Add(DiLoader.GetType<IConsumer>(tradeConsumerString));
            var processor = new MultiTradeProcessor(queue, consumers);
            processor.Start();
            var readKey = ' ';
            Task.Factory.StartNew(() => Run(queue, loader));
            while (readKey != 'm')
            {

                readKey = Console.ReadKey().KeyChar;
            }
            _flag = false;
            processor.Stop();
        }

        private static void Run(TradeQueue queue, ILoader loader)
        {
            var i = 0;
            while (_flag)
            {
                i++;
                    Console.WriteLine("Reading ... " + i);
                    queue.Queue(loader.GetNext());
                
            }

        }
    }
}