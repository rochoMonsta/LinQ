using System;
namespace LinQ
{
    public class Product
    {
        public string Name { get; set; }
        public int Energy { get; set; }

        public Product(string name, int energy)
        {
            Name = name;
            Energy = energy;
        }
        public override string ToString()
        {
            return $"{Name} - ({Energy})";
        }
    }
}
