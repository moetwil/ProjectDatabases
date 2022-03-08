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
        }

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
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlRooms.Hide();

                // show students
                pnlStudents.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    /*StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    // clear the listview before filling it again
                    listViewStudents.Clear();

                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Name);
                        listViewStudents.Items.Add(li);
                    }*/
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                    LoggerService.WriteLog(e);
                }
            }
            else if (panelName == "Teachers")
            {
                // hide all panels and show the room panel
                HideAllPanels();
                pnlTeachers.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
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

                   
                    // fill the students listview within the students panel with a list of students
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
            imgDashboard.Hide();

            pnlStudents.Hide();

            pnlRooms.Hide();
            pictureStudents.Hide();

            pnlTeachers.Hide();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }
    }
}
