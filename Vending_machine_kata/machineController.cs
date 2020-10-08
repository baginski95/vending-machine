using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_machine_kata
{
    class MachineController
    {
        public VendingMachine VendingMachine { get; }
        public MachineController()
        {

        }
        private Dictionary<Coin,int> InsertStartingCoins()
        {
            var startingCoins = new Dictionary<Coin, int>()
            {
                { Coin.FiveZL, 10 },
                { Coin.TwoZL, 10 },
                { Coin.OneZL, 10 },
                { Coin.FiftyGR, 10 },
                { Coin.TwentyGR, 10 },
                { Coin.TenGR, 10 },
            };
            return startingCoins;
        }
        private Dictionary<int,Product> InsertStartingProducts()
        {

        }
    }
}
