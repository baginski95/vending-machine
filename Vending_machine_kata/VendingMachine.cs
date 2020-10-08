using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_machine_kata
{
    public sealed class VendingMachine
    {

        public Dictionary<int, Product> OwnedProducts { get; set; }
        public Dictionary<Coin, int> OwnedCoins { get; set; }
        public int CurrentValue { get; set; }
        public int Change { get; set; }
        private VendingMachine( Dictionary<Coin,int> ownedCoins, Dictionary<int, Product> ownedProducts)
        {
            OwnedCoins = ownedCoins;
            OwnedProducts = ownedProducts;
            CurrentValue = 0;
        }
        private static VendingMachine _instance;
        public static VendingMachine GetInstance(Dictionary<Coin, int> ownedCoins, Dictionary<int, Product> ownedProducts)
        {
            if(_instance == null)
            {
                _instance = new VendingMachine(ownedCoins, ownedProducts);
            }
            return _instance;
        }
        public void RemoveProduct(Product product)
        {
            OwnedProducts[product.Id].ProductCounter -= 1;
        }
        public bool HasProduct(Product product)
        {
            if (OwnedProducts[product.Id].ProductCounter >= 1) return true;
            return false;
        }
        public bool HasCoins()
        {
            if (OwnedCoins[Coin.FiveZL] >= 1 && OwnedCoins[Coin.TwoZL] >= 1 &&
                OwnedCoins[Coin.OneZL] >= 1 && OwnedCoins[Coin.FiftyGR] >= 1 &&
                OwnedCoins[Coin.TwentyGR] >= 1 && OwnedCoins[Coin.TenGR] >= 1) return true;
            return false;
        }

       
        
    }
}
