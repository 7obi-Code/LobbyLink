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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnDeleteItemDefinition = new Button();
            BtnDeleteAccount = new Button();
            SuspendLayout();
            // 
            // BtnCreateItemInstance
            // 
            BtnCreateItemInstance.Location = new Point(195, 57);
            BtnCreateItemInstance.Name = "BtnCreateItemInstance";
            BtnCreateItemInstance.Size = new Size(165, 30);
            BtnCreateItemInstance.TabIndex = 0;
            BtnCreateItemInstance.Text = "Create Item Instance";
            BtnCreateItemInstance.Click += BtnCreateItemInstance_Click;
            // 
            // BtnCreateAccount
            // 
            BtnCreateAccount.Location = new Point(32, 57);
            BtnCreateAccount.Name = "BtnCreateAccount";
            BtnCreateAccount.Size = new Size(120, 30);
            BtnCreateAccount.TabIndex = 1;
            BtnCreateAccount.Text = "Create Account";
            BtnCreateAccount.UseVisualStyleBackColor = true;
            BtnCreateAccount.Click += BtnCreateAccount_Click;
            // 
            // BtnCreateItemDefinition
            // 
            BtnCreateItemDefinition.Location = new Point(195, 93);
            BtnCreateItemDefinition.Name = "BtnCreateItemDefinition";
            BtnCreateItemDefinition.Size = new Size(165, 30);
            BtnCreateItemDefinition.TabIndex = 2;
            BtnCreateItemDefinition.Text = "Create Item Definition";
            BtnCreateItemDefinition.UseVisualStyleBackColor = true;
            BtnCreateItemDefinition.Click += BtnCreateItemDefinition_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 34);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 3;
            label1.Text = "Account Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 34);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Item Options";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveBorder;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(302, 9);
            label3.Name = "label3";
            label3.Size = new Size(165, 22);
            label3.TabIndex = 5;
            label3.Text = "LobbyLink Admin Panel";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnDeleteItemDefinition
            // 
            BtnDeleteItemDefinition.Location = new Point(208, 129);
            BtnDeleteItemDefinition.Name = "BtnDeleteItemDefinition";
            BtnDeleteItemDefinition.Size = new Size(140, 29);
            BtnDeleteItemDefinition.TabIndex = 9;
            BtnDeleteItemDefinition.Text = "Delete Items";
            BtnDeleteItemDefinition.UseVisualStyleBackColor = true;
            BtnDeleteItemDefinition.Click += BtnDeleteItemDefinition_Click;
            // 
            // BtnDeleteAccount
            // 
            BtnDeleteAccount.Location = new Point(23, 93);
            BtnDeleteAccount.Name = "BtnDeleteAccount";
            BtnDeleteAccount.Size = new Size(140, 29);
            BtnDeleteAccount.TabIndex = 11;
            BtnDeleteAccount.Text = "Delete Accounts";
            BtnDeleteAccount.UseVisualStyleBackColor = true;
            BtnDeleteAccount.Click += BtnDeleteAccount_Click;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(782, 453);
            Controls.Add(BtnDeleteAccount);
            Controls.Add(BtnDeleteItemDefinition);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnCreateItemDefinition);
            Controls.Add(BtnCreateAccount);
            Controls.Add(BtnCreateItemInstance);
            Name = "AdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BtnCreateAccount;
        private Button BtnCreateItemDefinition;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button BtnDeleteItemDefinition;
        private Button BtnDeleteAccount;
    }
}