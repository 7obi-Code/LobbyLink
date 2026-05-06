using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LobbyLink.Desktop
{
    public partial class CreateAccounts : Form
    {
        private readonly AccountApiClient apiClient;

        public CreateAccounts(AccountApiClient apiClient)
        {
            InitializeComponent();
            this.apiClient = apiClient;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Username is required.");
                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Email is required.");
                    txtEmail.Focus();
                    return;
                }

                if (!int.TryParse(txtLevel.Text, out int level))
                {
                    MessageBox.Show("Level must be a number.");
                    txtLevel.Focus();
                    return;
                }

                // Create model
                Account account = new Account
                {
                    UserName = txtUserName.Text,
                    FirstName = txtFirstName.Text,
                    SurName = txtSurName.Text,
                    Email = txtEmail.Text,
                    PhoneNo = txtPhoneNo.Text,
                    Level = level,
                    Type = cmbType.Text
                };

                // Call API
                int newId = apiClient.InsertAccount(account);

                MessageBox.Show($"Account created.\nID: {newId}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Clear fields
                txtUserName.Clear();
                txtFirstName.Clear();
                txtSurName.Clear();
                txtEmail.Clear();
                txtPhoneNo.Clear();
                txtLevel.Clear();
                cmbType.Items.Clear();

                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}