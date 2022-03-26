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
    public partial class PasswordRecoveryForm2 : Form
    {

        public PasswordRecoveryForm2()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string newPassword = textNewPassword.Text;
            string verifyPassword = textVerifyPassword.Text;

            // if the first password is het same as the second password than the password will be saved
            try
            {
                if (newPassword != verifyPassword)
                {
                    throw new Exception("The passwords do not match. Please try again.");
                }
                else
                {
                    HashSalt hashSalt = new HashSalt(newPassword, verifyPassword);
                    HashSaltService hashSaltService = new HashSaltService();
                    hashSaltService.UpdatePassword(hashSalt);
                    this.Close();
                    MessageBox.Show("Password is verified and will be updated.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with resetting the password: " + exception.Message);
                LoggerService.WriteLog(exception);
            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // if you push the button than the password will be encrypted

            string newPassword = textNewPassword.Text;
            string verifyPassword = textVerifyPassword.Text;

            if (e.Clicks == 1)
            {
                textNewPassword.PasswordChar = '*';
                textVerifyPassword.PasswordChar = '*';
            }
        }
    }
}
