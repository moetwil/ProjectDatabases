using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        public int DrinkId { get; set; } 
        public bool HasAlcohol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }
    }
}
