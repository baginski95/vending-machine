using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_machine_kata
{
    public class VendingMachine
    {

        public Dictionary<int, Product> OwnedProducts { get; set; }
        public Dictionary<Coin, int> OwnedCoins { get; set; }
        public void RemoveProduct(Product product)
        {
            OwnedProducts[product.Id].ProductCounter -= 1;
        }
        public bool HasProduct(Product product)
        {
            if (OwnedProducts.ContainsKey(product.Id) && OwnedProducts[product.Id].ProductCounter >= 1)
            {
                return true;
            }
            return false;
        }

       
        
    }
}
