namespace OOP_GROUP_29
{
    partial class UpdateUserProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnUpdateUserName = new System.Windows.Forms.Button();
            this.btnUpdatePhone = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnUpdateEmail = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(50, 90);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(76, 16);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User Name";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(50, 130);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(46, 16);
            this.labelPhone.TabIndex = 1;
            this.labelPhone.Text = "Phone";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(50, 170);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 16);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(50, 210);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(41, 16);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(100, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(362, 42);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Update User Profile";
            // 
            // btnUpdateUserName
            // 
            this.btnUpdateUserName.Location = new System.Drawing.Point(400, 80);
            this.btnUpdateUserName.Name = "btnUpdateUserName";
            this.btnUpdateUserName.Size = new System.Drawing.Size(150, 30);
            this.btnUpdateUserName.TabIndex = 5;
            this.btnUpdateUserName.Text = "Update User Name";
            this.btnUpdateUserName.UseVisualStyleBackColor = true;
            this.btnUpdateUserName.Click += new System.EventHandler(this.UpdateUserName_Click);
            // 
            // btnUpdatePhone
            // 
            this.btnUpdatePhone.Location = new System.Drawing.Point(400, 120);
            this.btnUpdatePhone.Name = "btnUpdatePhone";
            this.btnUpdatePhone.Size = new System.Drawing.Size(150, 30);
            this.btnUpdatePhone.TabIndex = 6;
            this.btnUpdatePhone.Text = "Update Phone";
            this.btnUpdatePhone.UseVisualStyleBackColor = true;
            this.btnUpdatePhone.Click += new System.EventHandler(this.UpdatePhone_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Location = new System.Drawing.Point(400, 160);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(150, 30);
            this.btnUpdatePassword.TabIndex = 7;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.UpdatePassword_Click);
            // 
            // btnUpdateEmail
            // 
            this.btnUpdateEmail.Location = new System.Drawing.Point(400, 200);
            this.btnUpdateEmail.Name = "btnUpdateEmail";
            this.btnUpdateEmail.Size = new System.Drawing.Size(150, 30);
            this.btnUpdateEmail.TabIndex = 8;
            this.btnUpdateEmail.Text = "Update Email";
            this.btnUpdateEmail.UseVisualStyleBackColor = true;
            this.btnUpdateEmail.Click += new System.EventHandler(this.UpdateEmail_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(150, 130);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 22);
            this.txtPhone.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateUserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnUpdateEmail);
            this.Controls.Add(this.btnUpdatePassword);
            this.Controls.Add(this.btnUpdatePhone);
            this.Controls.Add(this.btnUpdateUserName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelUserName);
            this.Name = "UpdateUserProfileForm";
            this.Text = "Update User Profile";
            this.Load += new System.EventHandler(this.UpdateUserProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnUpdateUserName;
        private System.Windows.Forms.Button btnUpdatePhone;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.Button btnUpdateEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button button1;
    }
}
