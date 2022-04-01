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
        private string username;
        private User user;

        public PasswordRecoveryForm2(User user)
        {
            this.user = user;
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
                    HashSaltService hashSaltService = new HashSaltService();

                    HashSalt newHashSalt = HashSaltService.GenerateSaltedHash(100, newPassword);
                    user.HashSalt = newHashSalt;
                    hashSaltService.UpdatePassword(user);

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

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            // if you push the button than the password will be encrypted

            string newPassword = textNewPassword.Text;
            string verifyPassword = textVerifyPassword.Text;

            if (e.Clicks == 1)
            {
                textNewPassword.ToString();
                textVerifyPassword.ToString();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm backToLogin = new LoginForm();
            backToLogin.ShowDialog();
            this.Close();
        }
    }
}
