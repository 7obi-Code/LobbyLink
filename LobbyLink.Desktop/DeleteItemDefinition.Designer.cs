namespace LobbyLink.Desktop
{
    partial class DeleteItemDefinition
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
            dgvItemDefinitions = new DataGridView();
            BtnCancel = new Button();
            BtnConfirm = new Button();
            BtnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItemDefinitions).BeginInit();
            SuspendLayout();
            // 
            // dgvItemDefinitions
            // 
            dgvItemDefinitions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItemDefinitions.Dock = DockStyle.Bottom;
            dgvItemDefinitions.Location = new Point(0, 47);
            dgvItemDefinitions.Name = "dgvItemDefinitions";
            dgvItemDefinitions.RowHeadersWidth = 51;
            dgvItemDefinitions.Size = new Size(782, 406);
            dgvItemDefinitions.TabIndex = 0;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.Red;
            BtnCancel.Location = new Point(12, 12);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(94, 29);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
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
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.DarkTurquoise;
            BtnRefresh.Location = new Point(576, 12);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(94, 29);
            BtnRefresh.TabIndex = 3;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.UseVisualStyleBackColor = false;
            // 
            // DeleteItemDefinition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(782, 453);
            Controls.Add(BtnRefresh);
            Controls.Add(BtnConfirm);
            Controls.Add(BtnCancel);
            Controls.Add(dgvItemDefinitions);
            Name = "DeleteItemDefinition";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delete ItemDefinition";
            ((System.ComponentModel.ISupportInitialize)dgvItemDefinitions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvItemDefinitions;
        private Button BtnCancel;
        private Button BtnConfirm;
        private Button BtnRefresh;
    }
}