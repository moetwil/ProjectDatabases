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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;

            try
            {
                if (username == String.Empty)
                    throw new Exception("No username entered");

                if (password == String.Empty)
                    throw new Exception("No password entered");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                
            }
        }
    }
}
