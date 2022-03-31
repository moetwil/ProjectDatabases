﻿using System;
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

            try
            {
                if (username == String.Empty)
                    throw new Exception("No username entered");

                if (password == String.Empty)
                    throw new Exception("No password entered");

                // get an user by the given username
                UserService userService = new UserService();
                User user = userService.GetUser(username);

                // als de methode een leeg user object returned bestaat de gebruiker niet
                if (user == null)
                    throw new Exception("Not an existing user");

                // verify the login
                HashSaltService hashSaltService = new HashSaltService();
                bool login = hashSaltService.VerifyPassword(password, user.HashSalt);

                //if login is true, open somerenui en sluit het inlog venster
                if (login)
                {
                    LoadSomerenUI();
                }
                else
                {
                    // toon message dat het wachtwoord niet klopt
                    MessageBox.Show("False password, try again");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                LoggerService.WriteLog(exception);
            }
            //uncomment dit voordat je het inlevert, anders verifieerd hij de login niet

            

            //MessageBox.Show(login.ToString());


            //LoadSomerenUI();
        }

        // method for switching to the SomerenUI form, also closes the login form
        void LoadSomerenUI()
        {
            this.Hide();
            SomerenUI somerenUI = new SomerenUI();
            somerenUI.ShowDialog();
            this.Close();
        }

        // register linklabel, if clicked then open register form and close the login form
        private void registerLInkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        // password recovery linklabel, if clicked then open passwordrecovery form and close the login form
        private void passwordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PasswordRecoveryForm password = new PasswordRecoveryForm();
            password.ShowDialog();
            this.Close();
        }
    }
}
