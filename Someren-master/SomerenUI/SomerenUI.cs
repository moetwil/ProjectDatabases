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
            HideAllPanels();

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
                //HideAllPanels();
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
                //HideAllPanels();
                pnlShop.Show();

                try
                {
                    // load the listview with all the students
                    LoadShopStudents();

                    // load the listview with all the drinks
                    LoadShopDrinks();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the shop: " + e.Message);
                    LoggerService.WriteLog(e);
                }

            }
            else if (panelName == "Revenue report")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlRevenue.Show();

                // ListView will show the results after the dates are selected
            }
            else if (panelName == "Drinks suplies")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlDrinksSuplies.Show();

                // ListView will show the results after the dates are selected
            }
            else if(panelName == "ActivityParticipants")
            {
                pnlActivityParticipants.Show();
                try
                {
                    LoadActivities();
                    LoadStudentsListBox();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the Activities: " + e.Message);
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
            pnlDrinksSuplies.Hide();
            pnlActivityParticipants.Hide();
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
            /*double totalPrice = 0;
            int studentId;*/
            PurchaseService purchaseService = new PurchaseService();

            purchaseService.PlaceOrder(listViewShopStudents, listViewShopDrinks);

            // clear the selected rows in both listviews
            listViewShopStudents.SelectedItems.Clear();
            listViewShopDrinks.SelectedItems.Clear();
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

            DateTime firstDay = new DateTime(2022, 5, 16);
            DateTime secondDay = new DateTime(2022, 5, 17);

            if (DateTime.TryParse(textBoxStart.Text, out firstDay) && DateTime.TryParse(textBoxEnd.Text, out secondDay))
            {

                try
                    {
                    // fill the purchases listview within the purchase panel with a list of purchases
                    PurchaseService purchaseService = new PurchaseService();
                    List<Purchase> purchaseList = purchaseService.GetPurchases();

                    // clear the listview before filling it again
                    listViewRevenue.Clear();

                    // styling of the listView
                    listViewRevenue.GridLines = true;
                    listViewRevenue.View = View.Details;

                    listViewRevenue.Columns.Add("Purchase id", 90);
                    listViewRevenue.Columns.Add("Drinks sold", 90);
                    listViewRevenue.Columns.Add("Turn over", 90);
                    listViewRevenue.Columns.Add("Customers", 90);

                    // add every purchase to the listView
                    foreach (Purchase purchase in purchaseList)
                    {
                         ListViewItem listPurchase = new ListViewItem(purchase.PurchaseId.ToString());
                        listPurchase.SubItems.Add(purchase.DrinksSold.ToString());
                        listPurchase.SubItems.Add(purchase.TurnOver.ToString());
                        listPurchase.SubItems.Add(purchase.NumberOfCustomers.ToString());
                        listViewRevenue.Items.Add(listPurchase);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Something went wrong while loading the revenue: {exc.Message} Please try refreshing the page or close the window and try again.");
                    LoggerService.WriteLog(exc);
                }
            }
            else
            {
                MessageBox.Show("Wrong date. Choose another one.");
            }
        }

       
        // event handler method - on listview select - listViewShopDrinks
        private void listViewShopDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            PurchaseService purchaseService = new PurchaseService();
            
            // calculate the total price and write to the label
            double totalPrice = purchaseService.TotalPrice(this.listViewShopDrinks.SelectedItems);
            orderPriceLabel.Text = $"Total price: \u20AC {totalPrice.ToString("0.00")}";

        }

        private void LoadShopStudents()
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
            listViewShopStudents.Columns.Add("student id", 80);
            listViewShopStudents.Columns.Add("student name", 90);
            listViewShopStudents.Columns.Add("Date of birth", 85);

            // fill the list view with students from the List
            foreach (Student student in studentList)
            {
                ListViewItem item = new ListViewItem(student.StudentId.ToString());
                item.Tag = student;
                item.SubItems.Add(student.FullName);
                item.SubItems.Add(student.DateOfBirth.ToString("dd-MM-yyyy"));

                listViewShopStudents.Items.Add(item);
            }
        }

        private void LoadShopDrinks()
        {
            DrinkService drinkService = new DrinkService();
            List<Drink> drinkList = drinkService.GetDrinks();

            listViewShopDrinks.Clear();

            // set styling for listView
            listViewShopDrinks.GridLines = true;
            listViewShopDrinks.View = View.Details;
            listViewShopDrinks.FullRowSelect = true;
            listViewShopDrinks.CheckBoxes = true;
            listViewShopDrinks.MultiSelect = true;

            // add columns to the listView
            listViewShopDrinks.Columns.Add("drink id", 50);
            listViewShopDrinks.Columns.Add("Drink name", 70);
            listViewShopDrinks.Columns.Add("Alcohol", 50);
            listViewShopDrinks.Columns.Add("Price", 50);
            listViewShopDrinks.Columns.Add("Stock", 40);

            foreach (Drink drink in drinkList)
            {
                ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                item.Tag = drink;
                item.SubItems.Add(drink.Name);
                item.SubItems.Add(drink.HasAlcohol.ToString());
                item.SubItems.Add(drink.Price.ToString("0.00"));
                item.SubItems.Add(drink.Stock.ToString());
                listViewShopDrinks.Items.Add(item);
            }
        }

        private void listViewShopDrinks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            double totalPrice = 0;

            // loop through all the selected items in the given listview
            foreach (ListViewItem item in listViewShopDrinks.CheckedItems)
            {
                // add the item price to the total price
                double price = double.Parse(item.SubItems[3].Text);
                totalPrice += price;

            }
            orderPriceLabel.Text = $"Total price: \u20AC {totalPrice.ToString("0.00")}";
        }

        private void drinksSuppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks suplies");

            DrinkService drinkService = new DrinkService();
            List<Drink> drinkList = drinkService.GetDrinks();

            listViewDrinkSuplies.Clear();

            // set styling for listView
            listViewDrinkSuplies.GridLines = true;
            listViewDrinkSuplies.View = View.Details;
            listViewDrinkSuplies.FullRowSelect = true;
            listViewDrinkSuplies.MultiSelect = true;

            // add columns to the listView
            listViewDrinkSuplies.Columns.Add("drink id", 50);
            listViewDrinkSuplies.Columns.Add("Drink name", 70);
            listViewDrinkSuplies.Columns.Add("Alcohol", 50);
            listViewDrinkSuplies.Columns.Add("Price", 50);
            listViewDrinkSuplies.Columns.Add("Stock", 40);

            foreach (Drink drink in drinkList)
            {
                ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                item.Tag = drink;
                item.SubItems.Add(drink.Name);
                item.SubItems.Add(drink.HasAlcohol.ToString());
                item.SubItems.Add(drink.Price.ToString("0.00"));
                item.SubItems.Add(drink.Stock.ToString());
                listViewDrinkSuplies.Items.Add(item);
            }

            
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            //listViewDrinkSuplies.SelectedItems[2].SubItems[2].Text = drinkBox.Text;
            //Update();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            DrinkService drinksService = new DrinkService();
            drinksService.AddDrinks(drinkBox.Text, int.Parse(stockBox.Text));
            Update();
        }

        // menu button Activity Participants
        private void activityParticipantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("ActivityParticipants");
        }

        private void LoadActivities()
        {
            ActivityService activityService = new ActivityService();
            List<Activity> activityList = activityService.GetActivities();

            listViewActivities.Clear();

            // set styling for listView
            listViewActivities.GridLines = true;
            listViewActivities.View = View.Details;
            listViewActivities.FullRowSelect = true;

            // add columns to the listView
            listViewActivities.Columns.Add("Id", 25);
            listViewActivities.Columns.Add("Description", 70);
            listViewActivities.Columns.Add("Start DateTime", 110);
            listViewActivities.Columns.Add("End DateTime", 110);

            foreach (Activity activity in activityList)
            {
                ListViewItem item = new ListViewItem(activity.ActivityId.ToString());
                item.Tag = activity;
                item.SubItems.Add(activity.Description);
                item.SubItems.Add(activity.StartDateTime.ToString("dd-MM-yyyy HH:mm"));
                item.SubItems.Add(activity.EndDateTime.ToString("dd-MM-yyyy HH:mm"));
                listViewActivities.Items.Add(item);
            }
        }

        // selected activity event method
        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int activityId = GetActivityId();


                //int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;

                LoadActivityStudents(activityId);
            }
            catch (Exception)
            {
                throw new Exception("No activity selected");
            }


            /*int activityId = GetActivityId();


            //int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;

            LoadActivityStudents(activityId);*/


        }

        private int GetActivityId() 
        {
            int activityId = 0;
            foreach (ListViewItem item in listViewActivities.SelectedItems)
            {
                //int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;
                activityId = ((Activity)(item.Tag)).ActivityId;
            }

            /*if (activityId == null)
                throw new Exception("No activity selected");*/

            return activityId;
        }

        private void LoadActivityStudents(int activityId)
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudentsByActivity(activityId);

            listViewActivityStudents.Clear();

            // set styling for listView
            listViewActivityStudents.GridLines = true;
            listViewActivityStudents.View = View.Details;
            listViewActivityStudents.FullRowSelect = true;

            // add columns to the listView
            listViewActivityStudents.Columns.Add("Id", 25);
            listViewActivityStudents.Columns.Add("Full Name", 70);

            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.StudentId.ToString());
                item.Tag = student;
                item.SubItems.Add(student.FullName);
                listViewActivityStudents.Items.Add(item);
            }
        }

        private void LoadStudentsListBox()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();

            foreach (Student student in students)
            {
                listBoxStudents.Items.Add(student);
            }
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            ActivityService activityService = new ActivityService();


            try
            {
                // get id of selected activity
                int activityId = GetActivityId();
                if (activityId == 0)
                    throw new Exception("No activity selected");

                // get id from selected student
                if (listBoxStudents.SelectedItem == null)
                    throw new Exception("No student selected");

                int studentId = ((Student)listBoxStudents.SelectedItem).StudentId;

                // check if student is in activity
                bool isInActivity = activityService.IsInActivity(activityId, studentId);

                if (!isInActivity)
                {
                    MessageBox.Show("Student added to activity");
                    //MessageBox.Show($"{activityId} + {studentId}");
                    //activityService.AddStudent(activityId, studentId);
                }
                else
                {
                    MessageBox.Show("Student already in activity");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with adding a student to an activity: " + exception.Message);
                LoggerService.WriteLog(exception);

            }

            



        }


        // check if a student is in a certain activity
        

    }
}
