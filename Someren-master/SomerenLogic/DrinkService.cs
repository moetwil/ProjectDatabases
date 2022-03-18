using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class DrinkService
    {
        DrinkDao drinkdb;

        public DrinkService()
        {
            drinkdb = new DrinkDao();
        }

        public List<Drink> GetDrinks()
        {
            // collect all rooms from the database
            List<Drink> drinks = drinkdb.GetAllDrinks();

            if (drinks.Count == 0)
                throw new Exception("No drinks loaded from the database.");

            return drinks;
        }

        public void AddDrinks(string drinkName, int stock, bool alcohol, double price, double vat)
        {
            drinkdb.AddDrinks(drinkName, stock, alcohol, price, vat);
        }

        //public bool ContainsAlcohol()

        
    }
}
