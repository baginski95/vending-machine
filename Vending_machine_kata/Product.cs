namespace Vending_machine_kata
{
    public class Product
    {

        public string Name { get; }
        public  int Price {get; }
        public int Id { get; }
        public int ProductCounter { get; set; }

        public Product(string name, float price, int id, int productCounter)
        {
            Price = price;
            Name = name;
            Id = id;
            ProductCounter = productCounter;
        }

    }
}
