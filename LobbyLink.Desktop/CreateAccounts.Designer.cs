namespace LobbyLink.Desktop
{
    partial class CreateAccounts
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
            txtUserName = new TextBox();
            txtFirstName = new TextBox();
            txtSurName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNo = new TextBox();
            txtLevel = new TextBox();
            confirmButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cmbType = new ComboBox();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(168, 114);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(182, 27);
            txtUserName.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(168, 147);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(182, 27);
            txtFirstName.TabIndex = 1;
            // 
            // txtSurName
            // 
            txtSurName.Location = new Point(168, 180);
            txtSurName.Name = "txtSurName";
            txtSurName.Size = new Size(182, 27);
            txtSurName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(168, 213);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPhoneNo
            // 
            txtPhoneNo.Location = new Point(168, 246);
            txtPhoneNo.Name = "txtPhoneNo";
            txtPhoneNo.Size = new Size(182, 27);
            txtPhoneNo.TabIndex = 4;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(168, 279);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(182, 27);
            txtLevel.TabIndex = 5;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(676, 412);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(94, 29);
            confirmButton.TabIndex = 7;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 409);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 114);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 9;
            label1.Text = "UserName:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 147);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 10;
            label2.Text = "FirstName:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 180);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 11;
            label3.Text = "SurName:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 213);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 12;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 246);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 13;
            label5.Text = "PhoneNo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(91, 279);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 14;
            label6.Text = "Level:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(94, 312);
            label7.Name = "label7";
            label7.Size = new Size(43, 20);
            label7.TabIndex = 15;
            label7.Text = "Type:";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "User", "Admin" });
            cmbType.Location = new Point(168, 312);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(182, 28);
            cmbType.TabIndex = 16;
            // 
            // CreateAccounts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(cmbType);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Controls.Add(txtLevel);
            Controls.Add(txtPhoneNo);
            Controls.Add(txtEmail);
            Controls.Add(txtSurName);
            Controls.Add(txtFirstName);
            Controls.Add(txtUserName);
            Name = "CreateAccounts";
            Text = "Account Creation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtFirstName;
        private TextBox txtSurName;
        private TextBox txtEmail;
        private TextBox txtPhoneNo;
        private TextBox txtLevel;
        private Button confirmButton;
        private Button cancelButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cmbType;
    }
}