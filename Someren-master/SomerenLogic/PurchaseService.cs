using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class PurchaseService
    {
        PurchaseDao purchasedb;

        public PurchaseService()
        {
            purchasedb = new PurchaseDao();
        }

        public void WritePurchase(int studentId, int drinkId)
        {
            purchasedb.WritePurchase(studentId, drinkId);
        }

        // load a list of purchases
        public List<Purchase> GetPurchases()
        {
            List<Purchase> purchases = purchasedb.GetAllPurchases();

            if (purchases.Count == 0)
            {
                throw new Exception("Not loaded from database");
            }

            return purchases;
        }

        public double TotalPrice(ListView.SelectedListViewItemCollection selectedItems)
        {
            // set starting totalPrice to zero
            double totalPrice = 0;

            // loop through all the selected items in the given listview
            foreach (ListViewItem item in selectedItems)
            {
                // add the item price to the total price
                double price = double.Parse(item.SubItems[3].Text);
                totalPrice += price;

            }

            return totalPrice;
        }
    }
}
