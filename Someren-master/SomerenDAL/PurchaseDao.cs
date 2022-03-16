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
            // write purchase to the database
            string query = $"INSERT INTO Purchases ([studentId], [drinkId]) VALUES ({studentId}, {drinkId})";
            
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public List<Purchase> GetAllPurchases()
        {
            // getting the information about the Purchases
            string query = "SELECT purchaseId, studentId, drinkId FROM [Purchases]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list of all the purchases
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Purchase> ReadTables(DataTable dataTable)
        {
            List<Purchase> purchases = new List<Purchase>();

            // if the datatable is empty send error message
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
