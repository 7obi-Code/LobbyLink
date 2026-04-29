namespace LobbyLink.Desktop
{
    partial class DeleteAccount
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
            dgvAccounts = new DataGridView();
            BtnRefresh = new Button();
            BtnConfirm = new Button();
            BtnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Dock = DockStyle.Bottom;
            dgvAccounts.Location = new Point(0, 47);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.Size = new Size(782, 406);
            dgvAccounts.TabIndex = 0;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.DarkTurquoise;
            BtnRefresh.Location = new Point(576, 12);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(94, 29);
            BtnRefresh.TabIndex = 1;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnConfirm
            // 
            BtnConfirm.BackColor = Color.Lime;
            BtnConfirm.Location = new Point(676, 12);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(94, 29);
            BtnConfirm.TabIndex = 2;
            BtnConfirm.Text = "Confirm";
            BtnConfirm.UseVisualStyleBackColor = false;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.Red;
            BtnCancel.Location = new Point(12, 12);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(94, 29);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // DeleteAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(782, 453);
            Controls.Add(BtnCancel);
            Controls.Add(BtnConfirm);
            Controls.Add(BtnRefresh);
            Controls.Add(dgvAccounts);
            Name = "DeleteAccount";
            Text = "Delete Account";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAccounts;
        private Button BtnRefresh;
        private Button BtnConfirm;
        private Button BtnCancel;
    }
}