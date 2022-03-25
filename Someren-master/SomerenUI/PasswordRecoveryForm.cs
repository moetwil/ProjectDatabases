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
    public partial class PasswordRecoveryForm : Form
    {
        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBoxUsername.Text != "piet@infhaarlem.nl")
            {
                MessageBox.Show("Wrong username and/or secret answer! Try again");

                if (textBoxUsername.Text == null)
                {
                    MessageBox.Show("Please fill in your username");
                }

            }
            else
            {
                MessageBox.Show("Correct answer and username");

                this.Hide();
                PasswordRecoveryForm2 resetPassword = new PasswordRecoveryForm2();
                resetPassword.ShowDialog();
                this.Close();
            }
        }
    }
}
