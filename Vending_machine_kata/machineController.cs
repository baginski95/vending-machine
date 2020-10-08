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
            VendingMachine = VendingMachine.GetInstance(InsertStartingCoins(), InsertStartingProducts());
        }
        private Dictionary<Coin, int> InsertStartingCoins()
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
        private Dictionary<int, Product> InsertStartingProducts()
        {
            var snickers = new Product("snickers", 200, 65, 10);
            var cocaCola = new Product("coca-cola", 150, 66, 15);
            var chips = new Product("chips", 50, 67, 10);

            var startingProducts = new Dictionary<int, Product>()
            {
                {snickers.Id, snickers },
                {cocaCola.Id, cocaCola },
                {chips.Id, chips }
            };

            return startingProducts;
        }
        public bool IsCorrectCoin(string coin)
        {
            switch (coin)
            {
                case "FiveZL":
                case "TwoZL":
                case "OneZL":
                case "FiftyGR":
                case "TwentyGR":
                case "TenGR":
                    return true;
                default:
                    return false;
            }
        }
        public bool IsProductAvailable(int productId)
        {
            var isAvailable = productId switch
            {
                65 => true,
                66 => true,
                67 => true,
                _ => false
            };
            if( isAvailable && VendingMachine.HasProduct(VendingMachine.OwnedProducts[productId]))
            {
                return true;
            }
            return false;
        }
        public int ChangeCoinToValue(string coin)
        {
            var coinValue = coin switch
            {
                "FiveZL" => (int) Coin.FiveZL,
                "TwoZL" => (int) Coin.TwoZL,
                "OneZL" => (int) Coin.OneZL,
                "FiftyGR" => (int) Coin.FiftyGR,
                "TwentyGR" => (int) Coin.TwentyGR,
                "TenGR" => (int) Coin.TenGR,
                _ => 0
            };
            return coinValue;
        }
    }
}
