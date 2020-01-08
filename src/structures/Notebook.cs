using System;
using System.Text;

namespace csharp1.structures
{
    public struct Notebook
    {
        private readonly String model;
        private readonly String manufacturer;
        private readonly int price;

        public Notebook(string model, string manufacturer, int price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public override string ToString()
        {
            return "Model: " + model + 
                   "\nmanufacturer: " + manufacturer + 
                   "\nprice: " + price;
        }
    }
}