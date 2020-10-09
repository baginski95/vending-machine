using System;

namespace Vending_machine_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var Controller = new MachineController();
            Controller.viewModel.ShowProducts(Controller.vendingMachine.OwnedProducts);
            Controller.viewModel.Info();
            while (true)
            {
                if (Controller.vendingMachine.HasCoins()) Controller.viewModel.InsertCoin();
                else Controller.viewModel.ChangeNotAvailable();
                var userInput = Console.ReadLine();
                if (Controller.IsCorrectCoin(userInput))
                {
                    Controller.vendingMachine.CurrentValue += Controller.ChangeCoinToValue(userInput);
                    Controller.viewModel.UserCurrentAmount(Controller.vendingMachine.CurrentValue);
                }
                if (Controller.HasUserWantsCoins(userInput))
                {
                    Controller.viewModel.ReturnCoins(Controller.ReturnCoins(Controller.vendingMachine.CurrentValue));
                    Controller.ResetCurrentValue();
                }
                if (Controller.HasUserSelectProduct(userInput))
                {
                    int productId = Int32.Parse(userInput);
                    if (Controller.IsProductAvailable(productId))
                    {
                        var wantedProduct = Controller.vendingMachine.OwnedProducts[productId];
                        var userMoney = Controller.vendingMachine.CurrentValue;
                        if (userMoney >= wantedProduct.Price)
                        {
                            Controller.GetCoinGiveProduct(wantedProduct);
                            userMoney -=  wantedProduct.Price;
                            Controller.viewModel.GiveProductToCustomer(wantedProduct);
                            Controller.viewModel.ReturnCoins(Controller.ReturnCoins(userMoney));
                            Controller.ResetCurrentValue();
                        }
                       else Controller.viewModel.ProductPrice(wantedProduct);
                    }
                   else Controller.viewModel.SoldOut();
                }

            }
        }
    }
}
