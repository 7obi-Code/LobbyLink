namespace LobbyLink.Desktop
{
    partial class CreateItemInstanceForm
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
            this.lblItemDefinitionId = new System.Windows.Forms.Label();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtItemDefinitionId = new System.Windows.Forms.TextBox();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemDefinitionId
            // 
            this.lblItemDefinitionId.AutoSize = true;
            this.lblItemDefinitionId.Location = new System.Drawing.Point(32, 128);
            this.lblItemDefinitionId.Name = "lblItemDefinitionId";
            this.lblItemDefinitionId.Size = new System.Drawing.Size(137, 16);
            this.lblItemDefinitionId.TabIndex = 0;
            this.lblItemDefinitionId.Text = "Indtast Item Definition Id";
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Location = new System.Drawing.Point(32, 172);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(101, 16);
            this.lblAccountId.TabIndex = 1;
            this.lblAccountId.Text = "Indtast Account Id";
            // 
            // txtItemDefinitionId
            // 
            this.txtItemDefinitionId.Location = new System.Drawing.Point(223, 122);
            this.txtItemDefinitionId.Name = "txtItemDefinitionId";
            this.txtItemDefinitionId.Size = new System.Drawing.Size(123, 22);
            this.txtItemDefinitionId.TabIndex = 2;
            // 
            // txtAccountId
            // 
            this.txtAccountId.Location = new System.Drawing.Point(223, 166);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(123, 22);
            this.txtAccountId.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(333, 313);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(169, 27);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Item Instance";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // CreateItemInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 520);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.txtItemDefinitionId);
            this.Controls.Add(this.lblAccountId);
            this.Controls.Add(this.lblItemDefinitionId);
            this.Name = "CreateItemInstanceForm";
            this.Text = "CreateItemInstanceForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblItemDefinitionId;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtItemDefinitionId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button btnCreate;
    }
}