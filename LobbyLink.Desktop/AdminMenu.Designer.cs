namespace LobbyLink.Desktop
{
    partial class AdminMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Button BtnCreateItemInstance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            BtnCreateItemInstance = new Button();
            BtnCreateAccount = new Button();
            BtnCreateItemDefinition = new Button();
            BtnDeleteItemDefinition = new Button();
            BtnDeleteAccount = new Button();
            labelActiveUsers = new Label();
            labelActiveListings = new Label();
            labelActiveItemInstances = new Label();
            labelActiveGames = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCreateItemInstance
            // 
            BtnCreateItemInstance.Dock = DockStyle.Top;
            BtnCreateItemInstance.FlatStyle = FlatStyle.System;
            BtnCreateItemInstance.Location = new Point(0, 129);
            BtnCreateItemInstance.Name = "BtnCreateItemInstance";
            BtnCreateItemInstance.Size = new Size(181, 30);
            BtnCreateItemInstance.TabIndex = 0;
            BtnCreateItemInstance.Text = "Create Item Instance";
            BtnCreateItemInstance.Click += BtnCreateItemInstance_Click;
            // 
            // BtnCreateAccount
            // 
            BtnCreateAccount.Dock = DockStyle.Top;
            BtnCreateAccount.FlatStyle = FlatStyle.System;
            BtnCreateAccount.Location = new Point(0, 20);
            BtnCreateAccount.Name = "BtnCreateAccount";
            BtnCreateAccount.Size = new Size(181, 30);
            BtnCreateAccount.TabIndex = 1;
            BtnCreateAccount.Text = "Create Account";
            BtnCreateAccount.UseVisualStyleBackColor = true;
            BtnCreateAccount.Click += BtnCreateAccount_Click;
            // 
            // BtnCreateItemDefinition
            // 
            BtnCreateItemDefinition.Dock = DockStyle.Top;
            BtnCreateItemDefinition.FlatStyle = FlatStyle.System;
            BtnCreateItemDefinition.Location = new Point(0, 99);
            BtnCreateItemDefinition.Name = "BtnCreateItemDefinition";
            BtnCreateItemDefinition.Size = new Size(181, 30);
            BtnCreateItemDefinition.TabIndex = 2;
            BtnCreateItemDefinition.Text = "Create Item Definition";
            BtnCreateItemDefinition.UseVisualStyleBackColor = true;
            BtnCreateItemDefinition.Click += BtnCreateItemDefinition_Click;
            // 
            // BtnDeleteItemDefinition
            // 
            BtnDeleteItemDefinition.Dock = DockStyle.Top;
            BtnDeleteItemDefinition.FlatStyle = FlatStyle.System;
            BtnDeleteItemDefinition.Location = new Point(0, 159);
            BtnDeleteItemDefinition.Name = "BtnDeleteItemDefinition";
            BtnDeleteItemDefinition.Size = new Size(181, 29);
            BtnDeleteItemDefinition.TabIndex = 9;
            BtnDeleteItemDefinition.Text = "Delete Items";
            BtnDeleteItemDefinition.UseVisualStyleBackColor = true;
            BtnDeleteItemDefinition.Click += BtnDeleteItemDefinition_Click;
            // 
            // BtnDeleteAccount
            // 
            BtnDeleteAccount.Dock = DockStyle.Top;
            BtnDeleteAccount.FlatStyle = FlatStyle.System;
            BtnDeleteAccount.Location = new Point(0, 50);
            BtnDeleteAccount.Name = "BtnDeleteAccount";
            BtnDeleteAccount.Size = new Size(181, 29);
            BtnDeleteAccount.TabIndex = 11;
            BtnDeleteAccount.Text = "Delete Accounts";
            BtnDeleteAccount.UseVisualStyleBackColor = true;
            BtnDeleteAccount.Click += BtnDeleteAccount_Click;
            // 
            // labelActiveUsers
            // 
            labelActiveUsers.AutoSize = true;
            labelActiveUsers.Location = new Point(3, 16);
            labelActiveUsers.Name = "labelActiveUsers";
            labelActiveUsers.Size = new Size(0, 20);
            labelActiveUsers.TabIndex = 12;
            // 
            // labelActiveListings
            // 
            labelActiveListings.AutoSize = true;
            labelActiveListings.Location = new Point(3, 16);
            labelActiveListings.Name = "labelActiveListings";
            labelActiveListings.Size = new Size(0, 20);
            labelActiveListings.TabIndex = 13;
            // 
            // labelActiveItemInstances
            // 
            labelActiveItemInstances.AutoSize = true;
            labelActiveItemInstances.Location = new Point(3, 16);
            labelActiveItemInstances.Name = "labelActiveItemInstances";
            labelActiveItemInstances.Size = new Size(0, 20);
            labelActiveItemInstances.TabIndex = 14;
            // 
            // labelActiveGames
            // 
            labelActiveGames.AutoSize = true;
            labelActiveGames.Location = new Point(3, 16);
            labelActiveGames.Name = "labelActiveGames";
            labelActiveGames.Size = new Size(0, 20);
            labelActiveGames.TabIndex = 15;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelActiveUsers);
            panel1.Location = new Point(191, 391);
            panel1.Name = "panel1";
            panel1.Size = new Size(100, 50);
            panel1.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelActiveListings);
            panel2.Location = new Point(297, 391);
            panel2.Name = "panel2";
            panel2.Size = new Size(100, 50);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelActiveGames);
            panel3.Location = new Point(520, 391);
            panel3.Name = "panel3";
            panel3.Size = new Size(100, 50);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(labelActiveItemInstances);
            panel4.Location = new Point(403, 391);
            panel4.Name = "panel4";
            panel4.Size = new Size(100, 50);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.GrayText;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(BtnDeleteItemDefinition);
            panel5.Controls.Add(BtnCreateItemInstance);
            panel5.Controls.Add(BtnCreateItemDefinition);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(BtnDeleteAccount);
            panel5.Controls.Add(BtnCreateAccount);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(185, 453);
            panel5.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonFace;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 79);
            label3.Name = "label3";
            label3.Padding = new Padding(138, 0, 0, 0);
            label3.Size = new Size(183, 20);
            label3.TabIndex = 19;
            label3.Text = "Items";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(114, 0, 0, 0);
            label1.Size = new Size(183, 20);
            label1.TabIndex = 18;
            label1.Text = "Accounts";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(358, 9);
            label2.Name = "label2";
            label2.Size = new Size(165, 40);
            label2.TabIndex = 18;
            label2.Text = "Velkommen";
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(782, 453);
            Controls.Add(label2);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "AdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Panel";
            Load += AdminMenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BtnCreateAccount;
        private Button BtnCreateItemDefinition;
        private Button button1;
        private Button BtnDeleteItemDefinition;
        private Button BtnDeleteAccount;
        private Label labelActiveUsers;
        private Label labelActiveListings;
        private Label labelActiveItemInstances;
        private Label labelActiveGames;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}