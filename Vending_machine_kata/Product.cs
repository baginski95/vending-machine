namespace Vending_machine_kata
{
    public class Product
    {

        public string Name { get; }
        public  float Price {get; }
        public int Id { get; }

        public Product(string name, float price, int id)
        {
            Price = price;
            Name = name;
            Id = id;
        }

    }
}
