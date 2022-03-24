
namespace SomerenUI
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.questionTextbox = new System.Windows.Forms.TextBox();
            this.answerTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(202, 102);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(288, 31);
            this.usernameTextbox.TabIndex = 0;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(202, 174);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(288, 31);
            this.passwordTextbox.TabIndex = 1;
            // 
            // questionTextbox
            // 
            this.questionTextbox.Location = new System.Drawing.Point(202, 238);
            this.questionTextbox.Name = "questionTextbox";
            this.questionTextbox.Size = new System.Drawing.Size(288, 31);
            this.questionTextbox.TabIndex = 2;
            // 
            // answerTextbox
            // 
            this.answerTextbox.Location = new System.Drawing.Point(202, 300);
            this.answerTextbox.Name = "answerTextbox";
            this.answerTextbox.Size = new System.Drawing.Size(288, 31);
            this.answerTextbox.TabIndex = 3;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answerTextbox);
            this.Controls.Add(this.questionTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox questionTextbox;
        private System.Windows.Forms.TextBox answerTextbox;
    }
}