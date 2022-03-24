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
                    LoadActivities(listViewActivities);
                    LoadStudentsListBox();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the Activities: " + e.Message);
                    LoggerService.WriteLog(e);
                }                
            }
            else if (panelName == "Activity Supervisors")
            {
                pnlActivitySupervisors.Show();
                try
                {
                    LoadActivities(listViewAllActivities);
                    LoadSupervisors();
                    //LoadSupervisors();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the Activities: " + e.Message);
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Activities")
            {
                pnlActivities.Show();
                try
                {
                    LoadActivities(listViewWithActivites);
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
            pnlActivitySupervisors.Hide();
            pnlActivities.Hide();
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

            DateTime startDate = DateTime.Parse(textBoxStart.Text);
            DateTime endDate = DateTime.Parse(textBoxEnd.Text);

            DateTime minimumDate = new DateTime(2022, 3, 12);
            DateTime maximumDate = new DateTime(2022, 3, 19);

                try
                {

                    if (startDate < minimumDate || startDate > maximumDate)
                    {
                        throw new Exception("Choose a valid date between 12-03-22 and 19-03-22");
                    }
                    if (endDate > maximumDate || endDate < minimumDate)
                    {
                        throw new Exception("Choose a valid date between 12-03-22 and 19-03-22");
                    }


                    // fill the purchases listview within the purchase panel with a list of purchases
                    RevenueService revenueService = new RevenueService();
                    Revenue revenue = revenueService.GetRevenue(startDate, endDate);

                    // clear the listview before filling it again
                    listViewRevenue.Clear();

                    // styling of the listView
                    listViewRevenue.GridLines = true;
                    listViewRevenue.View = View.Details;

                    listViewRevenue.Columns.Add("Drinks sold", 90);
                    listViewRevenue.Columns.Add("Turn over", 90);
                    listViewRevenue.Columns.Add("Customers", 90);

                    // add every purchase to the listView
                    ListViewItem listRevenue = new ListViewItem(revenue.DrinksSold.ToString());
                    listRevenue.SubItems.Add($"\u20AC {revenue.TurnOver.ToString("0.00")}");
                    listRevenue.SubItems.Add(revenue.NumberOfCustomers.ToString());
                    listViewRevenue.Items.Add(listRevenue);


                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Something went wrong while loading the revenue: {exc.Message} Please try refreshing the page or close the window and try again.");
                    LoggerService.WriteLog(exc);
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
            //listViewShopStudents.Columns.Add("student id", 80);
            listViewShopStudents.Columns.Add("student name", 90);
            listViewShopStudents.Columns.Add("Date of birth", 85);

            // fill the list view with students from the List
            foreach (Student student in studentList)
            {
                //ListViewItem item = new ListViewItem(student.StudentId.ToString());
                ListViewItem item = new ListViewItem(student.FullName);
                item.Tag = student;
                //item.SubItems.Add(student.FullName);
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
           // listViewShopDrinks.Columns.Add("drink id", 50);
            listViewShopDrinks.Columns.Add("Drink name", 70);
            listViewShopDrinks.Columns.Add("Alcohol", 50);
            listViewShopDrinks.Columns.Add("Price", 50);
            listViewShopDrinks.Columns.Add("Stock", 40);

            foreach (Drink drink in drinkList)
            {
                //ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                ListViewItem item = new ListViewItem(drink.Name);
                item.Tag = drink;
                //item.SubItems.Add(drink.Name);
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
            listViewDrinkSuplies.Columns.Add("VAT", 40);

            foreach (Drink drink in drinkList)
            {
                ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                item.Tag = drink;
                item.SubItems.Add(drink.Name);
                item.SubItems.Add(drink.HasAlcohol.ToString());
                item.SubItems.Add(drink.Price.ToString("0.00"));
                item.SubItems.Add(drink.Stock.ToString());
                item.SubItems.Add(drink.VAT.ToString());
                listViewDrinkSuplies.Items.Add(item);
            }

            
        }

      

        // menu button Activity Participants
        private void activityParticipantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("ActivityParticipants");
        }

        private void LoadActivities(ListView listview)
        {
            ActivityService activityService = new ActivityService();
            List<Activity> activityList = activityService.GetActivities();

            listview.Clear();

            // set styling for listView
            listview.GridLines = true;
            listview.View = View.Details;
            listview.FullRowSelect = true;

            // add columns to the listView
            listview.Columns.Add("Id", 25);
            listview.Columns.Add("Description", 70);
            listview.Columns.Add("Start DateTime", 110);
            listview.Columns.Add("End DateTime", 110);

            foreach (Activity activity in activityList)
            {
                ListViewItem item = new ListViewItem(activity.ActivityId.ToString());
                item.Tag = activity;
                item.SubItems.Add(activity.Description);
                item.SubItems.Add(activity.StartDateTime.ToString("dd-MM-yyyy HH:mm"));
                item.SubItems.Add(activity.EndDateTime.ToString("dd-MM-yyyy HH:mm"));
                listview.Items.Add(item);
            }
        }

        // selected activity event method
        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int activityId = GetActivityId(listViewActivities);


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

        private int GetActivityId(ListView listview) 
        {
            int activityId = 0;
            foreach (ListViewItem item in listview.SelectedItems)
            {
                //int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;
                activityId = ((Activity)(item.Tag)).ActivityId;
            }

            /*if (activityId == null)
                throw new Exception("No activity selected");*/

            return activityId;
        }

        private int GetStudentId()
        {
            int studentId = 0;
            foreach (ListViewItem item in listViewActivityStudents.SelectedItems)
            {
                //int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;
                studentId = ((Student)(item.Tag)).StudentId;
            }

            return studentId;
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
                int activityId = GetActivityId(listViewActivities);
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
                    activityService.AddStudent(activityId, studentId);
                    LoadActivityStudents(activityId);
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

        private void deleteStudentActivityButton_Click(object sender, EventArgs e)
        {
            ActivityService activityService = new ActivityService();

            try
            {
                // get id of selected activity
                int activityId = GetActivityId(listViewActivities);
                if (activityId == 0)
                    throw new Exception("No activity selected");

                int studentId = GetStudentId();
                if (studentId == 0)
                    throw new Exception("No student selected");

                DialogResult deletePopUp = MessageBox.Show("Are you sure you want to delete the student from the activity?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (deletePopUp == DialogResult.Yes)
                {
                    activityService.DeleteStudent(activityId, studentId);
                    LoadActivityStudents(activityId);
                }
                else if (deletePopUp == DialogResult.No)
                {
                    MessageBox.Show("Delete has been canceled");
                }

                


            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with deleting a student from an activity: " + exception.Message);
                LoggerService.WriteLog(exception);
            }
        }

        private int GetSupervicorId()
        {
            int supervisorId = 0;
            foreach (ListViewItem item in listViewAllActivities.SelectedItems)
            {
                int activityId = ((Activity)(listViewActivities.SelectedItems[0].Tag)).ActivityId;
                supervisorId = ((Teacher)(item.Tag)).TeacherId;
            }

            return supervisorId;
        }

        private void LoadActivitySupervisor(int activityId)
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeacherByActivity(activityId);

            listViewAllActivities.Clear();

            // set styling for listView
            listViewAllActivities.GridLines = true;
            listViewAllActivities.View = View.Details;
            listViewAllActivities.FullRowSelect = true;

            // add columns to the listView
            listViewAllActivities.Columns.Add("Id", 25);
            listViewAllActivities.Columns.Add("First name", 70);
            listViewAllActivities.Columns.Add("Last name", 70);

            foreach (Teacher teacher in teachers)
            {
                ListViewItem item = new ListViewItem(teacher.TeacherId.ToString());
                item.Tag = teacher;
                item.SubItems.Add(teacher.FirstName);
                item.SubItems.Add(teacher.LastName);
                listViewAllActivities.Items.Add(item);
            }
        }

        private void LoadSupervisors()
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeachers();

            listViewAllSupervisors.Clear();

            // set styling for listView
            listViewAllSupervisors.GridLines = true;
            listViewAllSupervisors.View = View.Details;
            listViewAllSupervisors.FullRowSelect = true;

            // add columns to the listView
            listViewAllSupervisors.Columns.Add("Id", 25);
            listViewAllSupervisors.Columns.Add("First name", 70);
            listViewAllSupervisors.Columns.Add("Last name", 70);

            foreach (Teacher teacher in teachers)
            {
                ListViewItem item = new ListViewItem(teacher.TeacherId.ToString());
                item.Tag = teacher;
                item.SubItems.Add(teacher.FirstName);
                item.SubItems.Add(teacher.LastName);
                listViewAllSupervisors.Items.Add(item);
            }
        }



        private void listViewAllActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int activityId = GetActivityId(listViewAllActivities);


                //int activityId = ((Activity)(listViewAllActivities.SelectedItems[0].Tag)).ActivityId;

                if (activityId == 0)
                {
                    listViewActivitiesSupervisors.Items.Clear();
                }

                LoadActivitySupervisors(activityId);
            }
            catch (Exception)
            {
                //throw new Exception("No activity selected");
            }
        }

        private void LoadActivitySupervisors(int activityId)
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeacherByActivity(activityId);

            listViewActivitiesSupervisors.Clear();

            // set styling for listView
            listViewActivitiesSupervisors.GridLines = true;
            listViewActivitiesSupervisors.View = View.Details;
            listViewActivitiesSupervisors.FullRowSelect = true;

            // add columns to the listView
            listViewActivitiesSupervisors.Columns.Add("Id", 25);
            listViewActivitiesSupervisors.Columns.Add("Firstname", 70);
            listViewActivitiesSupervisors.Columns.Add("Lastname", 70);

            foreach (Teacher teacher in teachers)
            {
                ListViewItem item = new ListViewItem(teacher.TeacherId.ToString());
                item.Tag = teacher;
                item.SubItems.Add(teacher.FirstName);
                item.SubItems.Add(teacher.LastName);
                listViewActivitiesSupervisors.Items.Add(item);
            }
        }

        private void buttonAddSupervisor_Click(object sender, EventArgs e)
        {
            /*
            ActivityService activityService = new ActivityService();

           try
           {
               // get id of selected activity
               int activityId = GetActivityId(listViewActivities);
               if (activityId == 0)
                   throw new Exception("No activity selected");

               // get id from selected supervisor
               if (listViewAllSupervisors == null)
                   throw new Exception("No student selected");

               int teacherId = listViewAllSupervisors.TeacherId;

               // check if supervisor is in activity
               bool isInActivity = activityService.IsInActivity(activityId, teacherId);

               if (!isInActivity)
               {
                   MessageBox.Show("Supervisor added to activity");
                   activityService.AddSupervisor(activityId, teacherId);
                   LoadActivitySupervisor(activityId);
               }
               else
               {
                   MessageBox.Show("Supervisor is already in this activity");
               }
           }
           catch (Exception exception)
           {
               MessageBox.Show("Something went wrong with adding a supervisor to an activity: " + exception.Message);
               LoggerService.WriteLog(exception);
           }*/
        }

        private void buttonDeleteSupervisor_Click_1(object sender, EventArgs e)
        {
            //Button button = new Button();
            //button.Enabled = false;

            Teacher teacher = new Teacher();

            foreach (ListViewItem item in listViewAllSupervisors.SelectedItems)
            {
                teacher = (Teacher)item.Tag;
            }
            int teacherId = teacher.TeacherId;

            MessageBox.Show(teacherId.ToString());
            ActivityService activityService = new ActivityService();

            try
            {

            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with deleting a supervisor from an activity: " + exception.Message);
                LoggerService.WriteLog(exception);
            }
        }

        private void activitySupervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activity Supervisors");
        }

        private void RefreshView()
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
            listViewDrinkSuplies.Columns.Add("VAT", 40);

            foreach (Drink drink in drinkList)
            {
                ListViewItem item = new ListViewItem(drink.DrinkId.ToString());
                item.Tag = drink;
                item.SubItems.Add(drink.Name);
                item.SubItems.Add(drink.HasAlcohol.ToString());
                item.SubItems.Add(drink.Price.ToString("0.00"));
                item.SubItems.Add(drink.Stock.ToString());
                item.SubItems.Add(drink.VAT.ToString());
                listViewDrinkSuplies.Items.Add(item);
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {

            try
            {
                DrinkService drinkService = new DrinkService();
                bool alcohol;
                if (alcoholButton.Checked)
                {
                    alcohol = true;
                }
                else
                {
                    alcohol = false;
                }

                if (drinkBox.Text == String.Empty || drinkBox.Text == String.Empty || stockBox.Text == String.Empty || priceBox.Text == String.Empty || VATbox.Text == String.Empty)
                {
                    throw new Exception("Make sure to enter all the data in the checkboxes");
                }

                drinkService.AddDrinks((drinkBox.Text).ToString(), int.Parse(stockBox.Text), alcohol,
                    double.Parse(priceBox.Text), double.Parse(VATbox.Text));
                RefreshView();
                alcoholButton.Checked = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with updating a drink " + exception.Message);
                LoggerService.WriteLog(exception);
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DrinkService drinkService = new DrinkService();

            

            try
            {
                if (drinkIdBox.Text == String.Empty)
                {
                    throw new Exception("Make sure to enter an Id");
                }

                drinkService.DeleteDrinks(int.Parse(drinkIdBox.Text));
                RefreshView();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with updating a drink " + exception.Message);
                LoggerService.WriteLog(exception);
            }
            

        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                DrinkService drinkService = new DrinkService();
                bool alcohol;
                if (alcoholButton.Checked)
                {
                    alcohol = true;
                }
                else
                {
                    alcohol = false;
                }

                if (drinkBox.Text == String.Empty || drinkBox.Text == String.Empty || stockBox.Text == String.Empty || priceBox.Text == String.Empty || VATbox.Text == String.Empty)
                {
                    throw new Exception("Make sure to enter all the data in the checkboxes");
                }

                drinkService.UpdateDrinks(int.Parse(drinkIdBox.Text), (drinkBox.Text).ToString(), int.Parse(stockBox.Text), alcohol,
                    double.Parse(priceBox.Text), double.Parse(VATbox.Text));
                RefreshView();
                alcoholButton.Checked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with updating a drink " + exception.Message);
                LoggerService.WriteLog(exception);
            }

           
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }





        // check if a student is in a certain activity


    }
}
