using System;

namespace Vending_machine_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var Controller = new MachineController();
            Controller.viewModel.ShowProducts(Controller.VendingMachine.OwnedProducts);
            Controller.viewModel.Info();
            while (true)
            {
                if (Controller.VendingMachine.HasCoins()) Controller.viewModel.InsertCoin();
                else Controller.viewModel.ChangeNotAvailable();
                var userInput = Console.ReadLine();
                if (Controller.IsCorrectCoin(userInput)
                {

                }

            }
        }
    }
}
