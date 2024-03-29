﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenDAL
{
    public class RevenueDao : BaseDao
    {
        public Revenue GetAllRevenues(DateTime start, DateTime end)
        {
            // getting the information about the Purchases
            string query = "SELECT COUNT(Purchases.drinkId) AS [Drinks sold], (SELECT COUNT(Purchases.drinkId) * AVG(Drinks.price) FROM Purchases JOIN Drinks ON Purchases.drinkId = Drinks.drinkId WHERE Purchases.date BETWEEN @Start AND @End) AS [Turn over], COUNT(DISTINCT Purchases.studentId) AS[Number of customers] FROM Purchases JOIN Drinks ON Purchases.drinkId = Drinks.drinkId WHERE Purchases.date BETWEEN @Start AND @End";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Start", start);
            sqlParameters[1] = new SqlParameter("@End", end);

            // return a list of all the purchases
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private Revenue ReadTables(DataTable dataTable)
        {
            // if the datatable is empty send error message
            if (dataTable == null)
                 throw new Exception("Datatable is empty");

            Revenue purchase = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                // create a purchase with with information from the database and add it to the list
                purchase = new Revenue()
                {
                    DrinksSold = (int)dr["Drinks sold"],
                    TurnOver = (decimal)dr["Turn over"],
                    NumberOfCustomers = (int)dr["Number of customers"]
                };
                //purchases.Add(purchase);
            }
            return purchase;
        }
    }
}
