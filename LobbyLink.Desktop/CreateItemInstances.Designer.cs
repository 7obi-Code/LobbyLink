namespace LobbyLink.Desktop
{
    partial class CreateItemInstances
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            lblItemDefinitionId = new Label();
            lblAccountId = new Label();
            txtItemDefinitionId = new TextBox();
            txtAccountId = new TextBox();
            confirmButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // lblItemDefinitionId
            // 
            lblItemDefinitionId.AutoSize = true;
            lblItemDefinitionId.Location = new Point(12, 87);
            lblItemDefinitionId.Name = "lblItemDefinitionId";
            lblItemDefinitionId.Size = new Size(175, 20);
            lblItemDefinitionId.TabIndex = 0;
            lblItemDefinitionId.Text = "Indtast Item Definition Id";
            // 
            // lblAccountId
            // 
            lblAccountId.AutoSize = true;
            lblAccountId.Location = new Point(58, 124);
            lblAccountId.Name = "lblAccountId";
            lblAccountId.Size = new Size(129, 20);
            lblAccountId.TabIndex = 1;
            lblAccountId.Text = "Indtast Account Id";
            // 
            // txtItemDefinitionId
            // 
            txtItemDefinitionId.Location = new Point(193, 87);
            txtItemDefinitionId.Margin = new Padding(3, 4, 3, 4);
            txtItemDefinitionId.Name = "txtItemDefinitionId";
            txtItemDefinitionId.Size = new Size(123, 27);
            txtItemDefinitionId.TabIndex = 2;
            // 
            // txtAccountId
            // 
            txtAccountId.Location = new Point(193, 124);
            txtAccountId.Margin = new Padding(3, 4, 3, 4);
            txtAccountId.Name = "txtAccountId";
            txtAccountId.Size = new Size(123, 27);
            txtAccountId.TabIndex = 3;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(670, 412);
            confirmButton.Margin = new Padding(3, 4, 3, 4);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(100, 30);
            confirmButton.TabIndex = 4;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += btnCreate_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 412);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // CreateItemInstances
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Controls.Add(txtAccountId);
            Controls.Add(txtItemDefinitionId);
            Controls.Add(lblAccountId);
            Controls.Add(lblItemDefinitionId);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CreateItemInstances";
            Text = "Create ItemInstance";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblItemDefinitionId;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtItemDefinitionId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button confirmButton;
        private Button cancelButton;
    }
}