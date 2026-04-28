namespace LobbyLink.Desktop
{
    partial class CreateItemDefinitions
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
            cancelButton = new Button();
            confirmButton = new Button();
            txtItemName = new TextBox();
            txtImageUrl = new TextBox();
            txtDescription = new TextBox();
            cmbGame = new ComboBox();
            name = new Label();
            label2 = new Label();
            desc = new Label();
            game = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 412);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(676, 412);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(94, 29);
            confirmButton.TabIndex = 1;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(160, 59);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(250, 27);
            txtItemName.TabIndex = 2;
            // 
            // txtImageUrl
            // 
            txtImageUrl.Location = new Point(160, 92);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.Size = new Size(250, 27);
            txtImageUrl.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(160, 125);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(250, 27);
            txtDescription.TabIndex = 4;
            // 
            // cmbGame
            // 
            cmbGame.FormattingEnabled = true;
            cmbGame.Location = new Point(160, 160);
            cmbGame.Name = "cmbGame";
            cmbGame.Size = new Size(250, 28);
            cmbGame.TabIndex = 5;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(102, 62);
            name.Name = "name";
            name.Size = new Size(52, 20);
            name.TabIndex = 6;
            name.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 95);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 7;
            label2.Text = "Image Url:";
            // 
            // desc
            // 
            desc.AutoSize = true;
            desc.Location = new Point(66, 128);
            desc.Name = "desc";
            desc.Size = new Size(88, 20);
            desc.TabIndex = 8;
            desc.Text = "Description:";
            // 
            // game
            // 
            game.AutoSize = true;
            game.Location = new Point(103, 161);
            game.Name = "game";
            game.Size = new Size(51, 20);
            game.TabIndex = 9;
            game.Text = "Game:";
            // 
            // CreateItemDefinitions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(game);
            Controls.Add(desc);
            Controls.Add(label2);
            Controls.Add(name);
            Controls.Add(cmbGame);
            Controls.Add(txtDescription);
            Controls.Add(txtImageUrl);
            Controls.Add(txtItemName);
            Controls.Add(confirmButton);
            Controls.Add(cancelButton);
            Name = "CreateItemDefinitions";
            Text = "Create ItemDefinition";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button confirmButton;
        private TextBox txtItemName;
        private TextBox txtImageUrl;
        private TextBox txtDescription;
        private ComboBox cmbGame;
        private Label name;
        private Label label2;
        private Label desc;
        private Label game;
    }
}