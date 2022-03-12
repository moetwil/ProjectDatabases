using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {      
        public List<Drink> GetAllDrinks()
        {
            // SQL query that selects the information that we need, where the roomId is bigger than 200
            string query = "SELECT drinkId, alcohol, drinkName, price, VAT, stock FROM [Drinks]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            if (dataTable == null)
                throw new Exception("Datatable is empty");

            foreach (DataRow dr in dataTable.Rows)
            {
                // create a room with with information from the database and add it to the list
                Drink drink = new Drink()
                {
                    DrinkId = (int)dr["drinkId"],
                    HasAlcohol = (bool)dr["alcohol"],
                    Name = (string)dr["drinkName"],
                    Price = Convert.ToDouble((decimal)(dr["price"])),
                    VAT = (double)dr["VAT"],
                    Stock = (int)dr["stock"]
                };
                drinks.Add(drink);
            }

            return drinks;
        }
    }
}
