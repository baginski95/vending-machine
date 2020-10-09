using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_machine_kata
{
    public class View
    {
        public void ShowProducts(Dictionary<int, Product> ownedProducts)
        {
            Console.WriteLine("Owned Products:");
            Console.WriteLine("Name | Id | Price");
            foreach(KeyValuePair<int, Product> product in ownedProducts)
            {
                Console.WriteLine($"{product.Value.Name} | {product.Value.Id} | {product.Value.Price});
            }
        }
        public void InsertCoin()
        {
            Console.WriteLine("Insert Coin");
        }
        public void ProductPrice(Product product)
        {
            Console.WriteLine($"Price: {product.Price}");
        }
        public void SoldOut()
        {
            Console.WriteLine("SOLD OUT");
        }
        public void GiveProductToCustomer(Product product)
        {
            Console.WriteLine($"Here is your {product.Name}");
            Console.WriteLine("THANK YOU");
        }
        public void ChangeNotAvailable()
        {
            Console.WriteLine("EXACT CHANGE ONLY");
        }
        public void Info()
        {
            Console.WriteLine("If u want to buy some stuff just insert Coins and select product ID");
            Console.WriteLine("If you want to give back your Coins just press RETURN");
        }
        public void UserCurrentAmount(int currentAmount)
        {
            Console.WriteLine($"Current Amount: {currentAmount}");
        }
    }
}
