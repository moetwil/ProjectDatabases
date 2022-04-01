
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
            this.resgisterUsernamelabel = new System.Windows.Forms.Label();
            this.registerPasswordlabel = new System.Windows.Forms.Label();
            this.LicensekeyLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(152, 82);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(217, 26);
            this.usernameTextbox.TabIndex = 0;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(152, 139);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(217, 26);
            this.passwordTextbox.TabIndex = 1;
            // 
            // questionTextbox
            // 
            this.questionTextbox.Location = new System.Drawing.Point(152, 190);
            this.questionTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.questionTextbox.Name = "questionTextbox";
            this.questionTextbox.Size = new System.Drawing.Size(217, 26);
            this.questionTextbox.TabIndex = 2;
            // 
            // resgisterUsernamelabel
            // 
            this.resgisterUsernamelabel.AutoSize = true;
            this.resgisterUsernamelabel.Location = new System.Drawing.Point(67, 88);
            this.resgisterUsernamelabel.Name = "resgisterUsernamelabel";
            this.resgisterUsernamelabel.Size = new System.Drawing.Size(83, 20);
            this.resgisterUsernamelabel.TabIndex = 4;
            this.resgisterUsernamelabel.Text = "Username";
            // 
            // registerPasswordlabel
            // 
            this.registerPasswordlabel.AutoSize = true;
            this.registerPasswordlabel.Location = new System.Drawing.Point(67, 145);
            this.registerPasswordlabel.Name = "registerPasswordlabel";
            this.registerPasswordlabel.Size = new System.Drawing.Size(78, 20);
            this.registerPasswordlabel.TabIndex = 5;
            this.registerPasswordlabel.Text = "Password";
            // 
            // LicensekeyLabel
            // 
            this.LicensekeyLabel.AutoSize = true;
            this.LicensekeyLabel.Location = new System.Drawing.Point(53, 196);
            this.LicensekeyLabel.Name = "LicensekeyLabel";
            this.LicensekeyLabel.Size = new System.Drawing.Size(94, 20);
            this.LicensekeyLabel.TabIndex = 6;
            this.LicensekeyLabel.Text = "License Key";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(152, 264);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(217, 59);
            this.RegisterButton.TabIndex = 7;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LicensekeyLabel);
            this.Controls.Add(this.registerPasswordlabel);
            this.Controls.Add(this.resgisterUsernamelabel);
            this.Controls.Add(this.questionTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox questionTextbox;
        private System.Windows.Forms.Label resgisterUsernamelabel;
        private System.Windows.Forms.Label registerPasswordlabel;
        private System.Windows.Forms.Label LicensekeyLabel;
        private System.Windows.Forms.Button RegisterButton;
    }
}