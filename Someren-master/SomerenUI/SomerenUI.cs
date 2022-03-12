using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();

            // button enter and leave
            dashboardToolStripMenuItem.MouseEnter += OnMouseEnterDashboard;
            dashboardToolStripMenuItem.MouseLeave += OnMouseLeaveDashboard;

            studentsToolStripMenuItem.MouseEnter += OnMouseEnterStudents;
            studentsToolStripMenuItem.MouseLeave += OnMouseLeaveStudents;

            lecturersToolStripMenuItem.MouseEnter += OnMouseEnterLecturers;
            lecturersToolStripMenuItem.MouseLeave += OnMouseLeaveLecturers;

            activitiesToolStripMenuItem.MouseEnter += OnMouseEnterActivities;
            activitiesToolStripMenuItem.MouseLeave += OnMouseLeaveActivities;

            roomsToolStripMenuItem.MouseEnter += OnMouseEnterRooms;
            roomsToolStripMenuItem.MouseLeave += OnMouseLeaveRooms;


            // monthcalendar range
            // only selects two days
            monthCalendar2.MaxSelectionCount = 2;

            // shows begin date and end date on calendar
            DateTime firstDayIntroduction = new DateTime(2022, 5, 16);
            DateTime secondDayIntroduction = new DateTime(2022, 5, 17);

            monthCalendar2.SelectionRange = new SelectionRange(firstDayIntroduction, secondDayIntroduction);

            
        }

   
        // button Dashboard
        private void OnMouseEnterDashboard(object sender, EventArgs e)
        {
            this.dashboardToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#2e8b57"); 
        }

        private void OnMouseLeaveDashboard(object sender, EventArgs e)
        {
            this.dashboardToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#4e8b57"); 
        }

        // button Students
        private void OnMouseEnterStudents(object sender, EventArgs e)
        {
            this.studentsToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#2e8b57");
        }

        private void OnMouseLeaveStudents(object sender, EventArgs e)
        {
            this.studentsToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#4e8b57"); 
        }

        // button Lecturers
        private void OnMouseEnterLecturers(object sender, EventArgs e)
        {
            this.lecturersToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#2e8b57"); 
        }

        private void OnMouseLeaveLecturers(object sender, EventArgs e)
        {
            this.lecturersToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#4e8b57"); 
        }

        // button Activities
        private void OnMouseEnterActivities(object sender, EventArgs e)
        {
            this.activitiesToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#2e8b57"); 
        }

        private void OnMouseLeaveActivities(object sender, EventArgs e)
        {
            this.activitiesToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#4e8b57"); // or Color.Red or whatever you want
        }

        // button Rooms
        private void OnMouseEnterRooms(object sender, EventArgs e)
        {
            this.roomsToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#2e8b57"); // or Color.Red or whatever you want
        }

        private void OnMouseLeaveRooms(object sender, EventArgs e)
        {
            this.roomsToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#4e8b57"); // or Color.Red or whatever you want
        }



        // All the panels
        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {
                // hide all other panels
                HideAllPanels();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                HideAllPanels();

                // show students
                pnlStudents.Show();

                try
                {
                    //fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    //clear the listview before filling it again
                    listViewStudents.Clear();

                    // set styling for listView
                    listViewStudents.GridLines = true;
                    listViewStudents.View = View.Details;

                    // add columns to the listView
                    listViewStudents.Columns.Add("student id", 90);
                    listViewStudents.Columns.Add("First name", 90);
                    listViewStudents.Columns.Add("Last name", 90);
                    listViewStudents.Columns.Add("Class", 90);
                    listViewStudents.Columns.Add("Date of birth", 85);
                    listViewStudents.Columns.Add("Room number", 90);

                    // fill the list view with students from the List
                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(new[] { s.StudentId.ToString(), s.FirstName, s.LastName,
                            s.Class, s.DateOfBirth.ToString("dd-MM-yyyy"), s.RoomId.ToString() });
                        listViewStudents.Items.Add(li);

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Teachers")
            {
                // hide all panels and show the teacher panel
                HideAllPanels();
                pnlTeachers.Show();

                try
                {
                    // fill the teachers listview within the teacher panel with a list of teachers
                    TeacherService teacherService = new TeacherService();
                    List<Teacher> teacherList = teacherService.GetTeachers();

                    // clear the listview before filling it again
                    listViewTeachers.Clear();

                    // styling of the listView
                    listViewTeachers.GridLines = true;
                    listViewTeachers.View = View.Details;

                    // create listView columns
                    listViewTeachers.Columns.Add("Lecturer number", 90);
                    listViewTeachers.Columns.Add("First name", 90);
                    listViewTeachers.Columns.Add("Last name", 90);
                    listViewTeachers.Columns.Add("Room number", 90);
                    listViewTeachers.Columns.Add("Supervisor", 90);

                    // add every teacher to the listView
                    foreach (Teacher teacher in teacherList)
                    {
                        ListViewItem listTeachter = new ListViewItem(teacher.TeacherId.ToString());
                        listTeachter.SubItems.Add(teacher.FirstName.ToString());
                        listTeachter.SubItems.Add(teacher.LastName.ToString());
                        listTeachter.SubItems.Add(teacher.RoomId.ToString());
                        listTeachter.SubItems.Add("Yes");
                        listViewTeachers.Items.Add(listTeachter);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Something went wrong while loading the teachers: {e.Message} Please try refreshing the page or close the window and try again.");
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlRooms.Show();

                try
                {
                    // fill the room listview within the room panel with a list of rooms
                    RoomService roomService = new RoomService(); 
                    List<Room> roomList = roomService.GetRooms(); 

                    // clear the listview before filling it again
                    listViewRooms.Clear();

                    // styling of the listView
                    listViewRooms.GridLines = true;
                    listViewRooms.View = View.Details;

                    // create listView columns
                    listViewRooms.Columns.Add("Room number", 90);
                    listViewRooms.Columns.Add("Capacity", 90);
                    listViewRooms.Columns.Add("Room type", 90);

                    // add every room to the listView
                    foreach (Room room in roomList)
                    {
                        ListViewItem li = new ListViewItem(room.Number.ToString());
                        li.SubItems.Add(room.Capacity.ToString());
                        li.SubItems.Add(roomService.IsTeacherRoom(room));
                        listViewRooms.Items.Add(li);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Shop")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlShop.Show();

                try
                {
                    //fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents();

                    //clear the listview before filling it again
                    listViewShopStudents.Clear();

                    // set styling for listView
                    listViewShopStudents.GridLines = true;
                    listViewShopStudents.View = View.Details;
                    listViewShopStudents.FullRowSelect = true;

                    // add columns to the listView
                    listViewShopStudents.Columns.Add("student id", 90);
                    listViewShopStudents.Columns.Add("First name", 90);
                    listViewShopStudents.Columns.Add("Last name", 90);
                    listViewShopStudents.Columns.Add("Class", 90);
                    listViewShopStudents.Columns.Add("Date of birth", 85);
                    listViewShopStudents.Columns.Add("Room number", 90);

                    // fill the list view with students from the List
                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(new[] { s.StudentId.ToString(), s.FirstName, s.LastName,
                            s.Class, s.DateOfBirth.ToString("dd-MM-yyyy"), s.RoomId.ToString() });
                        listViewShopStudents.Items.Add(li);

                    }



                    // drinks
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinkList = drinkService.GetDrinks();

                    listViewShopDrinks.Clear();

                    // set styling for listView
                    listViewShopDrinks.GridLines = true;
                    listViewShopDrinks.View = View.Details;
                    listViewShopDrinks.FullRowSelect = true;

                    // add columns to the listView
                    listViewShopDrinks.Columns.Add("drink id", 90);
                    listViewShopDrinks.Columns.Add("Drink name", 90);
                    listViewShopDrinks.Columns.Add("Alcohol", 90);

                    foreach (Drink drink in drinkList)
                    {
                        ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                        item.Tag = drink;
                        item.SubItems.Add(drink.Name);
                        item.SubItems.Add(drink.HasAlcohol.ToString());
                        listViewShopDrinks.Items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Revenue report")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlRevenue.Show();

                try
                {
                    // fill the purchases listview within the purchase panel with a list of purchases
                    PurchaseService purchaseService = new PurchaseService();
                    //List<Purchase> pruchaseList = purchaseService.WritePurchase();

                    // clear the listview before filling it again
                    listViewPurchases.Clear();

                    // styling of the listView
                    listViewPurchases.GridLines = true;
                    listViewPurchases.View = View.Details;

                    // create listView columns
                    listViewPurchases.Columns.Add("Drinks sold", 90);
                    listViewPurchases.Columns.Add("Turn over", 90);
                    listViewPurchases.Columns.Add("Number customers", 120);

                    // add every purchase to the listView
                    /*foreach (Purchase purchase in purchaseList)
                    {
                        ListViewItem listPurchase = new ListViewItem(purchase.DrinkId.ToString());
                        listPurchase.SubItems.Add(purchase.FirstName.ToString());
                        listPurchase.SubItems.Add(purchase.LastName.ToString());
                        listPurchase.SubItems.Add(purchase.RoomId.ToString());
                        listPurchases.Items.Add(listPurchase);
                    }*/
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Something went wrong while loading the teachers: {e.Message} Please try refreshing the page or close the window and try again.");
                    LoggerService.WriteLog(e);
                }
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        void HideAllPanels()
        {
            // hide every panel
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlRooms.Hide();
            pnlShop.Hide();
            pictureStudents.Hide();
            pnlTeachers.Hide();
            pnlRevenue.Hide();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Shop");
        }

        private void checkOutShopButton_Click(object sender, EventArgs e)
        {
            PurchaseService purchaseService = new PurchaseService();

            // get selected items
            int studentId = int.Parse(listViewShopStudents.SelectedItems[0].Text);
            int drinkId = int.Parse(listViewShopDrinks.SelectedItems[0].Text);

            // write the purchase to the database
            purchaseService.WritePurchase(studentId, drinkId);
            MessageBox.Show("Your order has been placed :)");
        }

        private void revenueReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Revenue report");
        }

        private void buttonRevenue_Click(object sender, EventArgs e)
        {
            // lables are linked to the selected dates on the calendar
            textBoxStart.Text = monthCalendar2.SelectionRange.Start.Date.ToString("dd-MM-yyyy");
            textBoxEnd.Text = monthCalendar2.SelectionRange.End.Date.ToString("dd-MM-yyyy");
        }
    }
}
