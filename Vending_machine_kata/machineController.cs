using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_machine_kata
{
    class MachineController
    {
        public View viewModel;
        public VendingMachine vendingMachine { get; }
        public MachineController()
        {
            vendingMachine = VendingMachine.GetInstance(InsertStartingCoins(), InsertStartingProducts());
            viewModel = new View();
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
            if( isAvailable && vendingMachine.HasProduct(vendingMachine.OwnedProducts[productId]))
            {
                return true;
            }
            return false;
        }
        public void GetCoinGiveProduct(Product product)
        {
            var coinsForMachine = this.ReturnCoins(product.Price);
            foreach(var coin in coinsForMachine)
            {
                this.vendingMachine.OwnedCoins[coin] += 1;
            }
            this.vendingMachine.RemoveProduct(product);
            

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
        public List<Coin> ReturnCoins(int currentValue)
        {
            var coinsToChange = new List<Coin>();
                if (currentValue - 500 >= 0)
                {
                    coinsToChange.Add(Coin.FiveZL);
                    currentValue -= 500;
                }
                if(currentValue - 200 >= 0)
                {
                    coinsToChange.Add(Coin.TwoZL);
                    currentValue -= 200;
                }
                if (currentValue - 100 >= 0)
                {
                    coinsToChange.Add(Coin.OneZL);
                    currentValue -= 100;
                }
                if (currentValue - 50 >= 0)
                {
                    coinsToChange.Add(Coin.FiftyGR);
                    currentValue -= 50;
                }
                if (currentValue - 20 >= 0)
                {
                    coinsToChange.Add(Coin.TwentyGR);
                    currentValue -= 20;
                }
                if (currentValue - 10 >= 0)
                {
                    coinsToChange.Add(Coin.TenGR);
                    currentValue -= 10;
                }
            return coinsToChange;
        }
        public void ResetCurrentValue()
        {
            vendingMachine.CurrentValue = 0;
            vendingMachine.Change = 0;
        }
        public bool HasUserWantsCoins(string userInput)
        {
            bool decision = userInput switch
            {
                "RETURN" => true,
                _ => false
            };
            return decision;
        }
        public bool HasUserSelectProduct(string userInput)
        {
            var decision = userInput switch
            {
                "65" => true,
                "66" => true,
                "67" => true,
                _ => false
            };
            return decision;
        }
    }
}
