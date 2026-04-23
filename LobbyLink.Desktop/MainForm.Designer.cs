namespace LobbyLink.Desktop
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnOpenCreateForm;

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
            //Control Panel Window
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Admin Panel";

            //Create ItemInstance Button
            btnOpenCreateForm = new Button();
            btnOpenCreateForm.Text = "Create Item Instance";
            btnOpenCreateForm.Location = new Point(50, 50);
            btnOpenCreateForm.Click += btnOpenCreateForm_Click;

            Controls.Add(btnOpenCreateForm);
        }
    }
}