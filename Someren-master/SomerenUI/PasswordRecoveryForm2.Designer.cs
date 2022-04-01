
namespace SomerenUI
{
    partial class PasswordRecoveryForm2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textVerifyPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textVerifyPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textNewPassword);
            this.groupBox1.Location = new System.Drawing.Point(158, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset password";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(35, 146);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(424, 41);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset password";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Verify password:";
            // 
            // textVerifyPassword
            // 
            this.textVerifyPassword.Location = new System.Drawing.Point(159, 95);
            this.textVerifyPassword.Name = "textVerifyPassword";
            this.textVerifyPassword.Size = new System.Drawing.Size(300, 22);
            this.textVerifyPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New password:";
            // 
            // textNewPassword
            // 
            this.textNewPassword.Location = new System.Drawing.Point(159, 62);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.Size = new System.Drawing.Size(300, 22);
            this.textNewPassword.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(17, 38);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(109, 39);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Back to Login";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // PasswordRecoveryForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 294);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.groupBox1);
            this.Name = "PasswordRecoveryForm2";
            this.Text = "PasswordRecoveryForm2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textVerifyPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.Button buttonBack;
    }
}