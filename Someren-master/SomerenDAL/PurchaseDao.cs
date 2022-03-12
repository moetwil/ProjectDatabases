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
    public class PurchaseDao : BaseDao
    {      
        public void WritePurchase(int studentId, int drinkId)
        {
            string query = $"INSERT INTO Purchases ([studentId], [drinkId]) VALUES ({studentId}, {drinkId})";
            
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
       

        private List<Purchase> ReadTables(DataTable dataTable)
        {
            List<Purchase> purchases = new List<Purchase>();

            if (dataTable == null)
                throw new Exception("Datatable is empty");

            foreach (DataRow dr in dataTable.Rows)
            {
                // create a purchase with with information from the database and add it to the list
                Purchase purchase = new Purchase()
                {
                    PurchaseId = (int)dr["purchaseId"],
                    StudentId = (int)dr["studentId"],
                    DrinkId = (int)dr["drinkId"],
                };
                purchases.Add(purchase);
            }

            return purchases;
        }
    }
}
