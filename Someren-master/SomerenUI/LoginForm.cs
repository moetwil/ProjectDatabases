using System;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // for testing

            /*string hash = "LUKjEWABxKwpc3R4u27CLi4ZoUlbdRVDdu0GnGoowaK3KL/TxKUUwigih9DBP/B2lc+9ZxOG253IhSmpZ/TryUqSW0vGFuRYcWSf3qIFoBDqSubkZv3Qe+mW2fi8cp3yCFEpjtYT+wyObPWsWzL1LalERyg6eQcmU7dahkpYAIDXYjMs27nawM37h7OP5Cg11AKI3J/RKJzGPEZ67r9sCHRJHPASlTL1LFEJTEUZxbjfSprq6y/Ve5wXJUFBbFOBicnRPXmbBJgsC4Ij1hA5N+MFTwmmpq/lEdtFfKtFjvRt7KYXVJVSp3rw78mnIl+Bc6OhvJE9P4YG/JDyPBdnKQ==";
            string salt = "pkBQcnWtztlIArwFEHtkDUTjfEqpePLu0zJLo7hpRXu7wV84AYwU6FJG00OHMnuvkG65HyRJYkH887pNzRqDlQ==";
            HashSalt hashSalt = new HashSalt(hash, salt);

            HashSaltService hashSaltService = new HashSaltService();
            bool login = hashSaltService.VerifyPassword(passwordTextBox.Text, hashSalt);

            MessageBox.Show(login.ToString());*/

            // save the textbox values
            string username = usernameTextbox.Text;
            string password = passwordTextBox.Text;

            // get an user by the given username
            UserService userService = new UserService();
            User user = userService.GetUser(username);

            // verify the login
            HashSaltService hashSaltService = new HashSaltService();
            bool login = hashSaltService.VerifyPassword(passwordTextBox.Text, user.HashSalt);

            MessageBox.Show(login.ToString());



            this.Hide();
            SomerenUI somerenUI = new SomerenUI();
            somerenUI.ShowDialog();
            this.Close();

            
        }
    }
}
