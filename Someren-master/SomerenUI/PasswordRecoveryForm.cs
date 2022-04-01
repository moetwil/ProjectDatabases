using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenLogic;
using SomerenModel;

namespace SomerenUI
{
    public partial class PasswordRecoveryForm : Form
    {
        private string username;

        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                string questionAnswer = textBoxAnswer.Text;
                UserService userService = new UserService();

                User user = userService.GetUser(questionAnswer);

                if (questionAnswer != "Toby")
                {
                    throw new Exception("Wrong answer. Please Try again");
                }
                else
                {
                    MessageBox.Show("Correct answer");

                    this.Hide();
                    PasswordRecoveryForm2 resetPassword = new PasswordRecoveryForm2(username);
                    resetPassword.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with answering the question: " + exception.Message);
                LoggerService.WriteLog(exception);
            }


        }

        private void getQuestionButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                string usernameText = textBoxUsername.Text;
                UserService userService = new UserService();

                User user = userService.GetUser(usernameText);
                if (user == null)
                    throw new Exception("Not an existing user");

                else
                {
                    MessageBox.Show("Correct username");
                    username = usernameText;
                    questionLabel.Text = user.Question;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong with entering the username: " + exception.Message);
                LoggerService.WriteLog(exception);
            }

        }

    }
}
