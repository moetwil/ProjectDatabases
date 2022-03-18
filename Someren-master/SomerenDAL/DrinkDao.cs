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
            string query = "SELECT drinkId, alcohol, drinkName, price, VAT, stock FROM [Drinks] ORDER BY stock, price";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void AddDrinks(string drinkName, int stock, bool alcohol, double price, double vat)
        {
            string query = $"INSERT INTO [Drinks] (drinkName, stock, alcohol, price, VAT) VALUES (@drinkName, @stock, @alcohol, @price, @VAT)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@drinkName", drinkName);
            sqlParameters[1] = new SqlParameter("@stock", stock);
            sqlParameters[2] = new SqlParameter("@alcohol", alcohol);
            sqlParameters[3] = new SqlParameter("@VAT", vat);
            sqlParameters[4] = new SqlParameter("@price", price);
            ExecuteEditQuery(query, sqlParameters);
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
