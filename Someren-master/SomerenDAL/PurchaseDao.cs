﻿using System;
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
            string query = "SELECT COUNT(Purchases.purchaseId) AS [Purchase id], COUNT(Purchases.drinkId) AS [Drinks sold]," +
                            "(SELECT COUNT(Purchases.drinkId) * AVG(Drinks.price)" +
                            "FROM Purchases JOIN Drinks ON Purchases.drinkId = Drinks.drinkId) AS [Turn over]" +
                            ", COUNT(DISTINCT Purchases.studentId) AS [Number of customers]" +
                            "FROM Purchases" +
                            "JOIN Drinks ON Purchases.drinkId = Drinks.drinkId";
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
                    PurchaseId = (int)dr["Purchase Id"],
                    DrinksSold = (int)dr["Drinks sold"],
                    TurnOver = (int)dr["Turn over"],
                    NumberOfCustomers = (int)dr["Number of customers"]
                };
                purchases.Add(purchase);
            }
            return purchases;
        }
    }
}
