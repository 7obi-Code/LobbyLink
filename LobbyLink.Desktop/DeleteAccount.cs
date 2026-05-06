using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LobbyLink.Desktop
{
    public partial class DeleteAccount : Form
    {
        private readonly AccountApiClient apiClient;

        public DeleteAccount(AccountApiClient apiClient)
        {
            InitializeComponent();
            this.apiClient = apiClient;

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                var accounts = apiClient.GetAllAccounts();
                dgvAccounts.DataSource = accounts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts:\n{ex.Message}");
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccounts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an account.");
                    return;
                }

                var selectedAccount = (Account)dgvAccounts.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show(
                    $"Delete account ID {selectedAccount.AccountId}?",
                    "Confirm",
                    MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    apiClient.DeleteAccount(selectedAccount.AccountId);

                    MessageBox.Show("Account deleted",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None);

                    LoadAccounts(); // refresh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting account:\n{ex.Message}");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


