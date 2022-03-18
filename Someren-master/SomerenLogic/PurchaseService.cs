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

        // write purchase to the database
        public void WritePurchase(int studentId, int drinkId)
        {
            purchasedb.WritePurchase(studentId, drinkId);
        }

        // load a list of purchases
        public List<Purchase> GetPurchases()
        {
            List<Purchase> purchases = purchasedb.GetAllPurchases();

            // if the list is empty, send error message
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

        public void PlaceOrder(ListView listViewShopStudents, ListView listViewShopDrinks)
        {
            int studentId;

            try
            {
                // get the student id
                if (listViewShopStudents.SelectedItems.Count == 0)
                    throw new Exception("No student selected.");
                else
                    studentId = int.Parse(listViewShopStudents.SelectedItems[0].Text);

                // check if there are any drinks selected, if not send error message
                if (listViewShopDrinks.CheckedItems.Count == 0)
                {
                    throw new Exception("No shop item(s) selected");
                }
                else
                {
                    foreach (ListViewItem item in listViewShopDrinks.Items)
                    {
                        if (item.Checked)
                        {
                            // get drink id
                            int drinkId = int.Parse(item.SubItems[0].Text);
                            //totalPrice += double.Parse(item.SubItems[3].Text);

                            // write purchase to the database
                            WritePurchase(studentId, drinkId);
                        }
                    }
                    // write nice message after the purchase has been done
                    MessageBox.Show("Your order has been placed :)");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong: " + exception.Message);
                LoggerService.WriteLog(exception);
            }
        }
    }
}
