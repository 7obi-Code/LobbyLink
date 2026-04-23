using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using System;
using System.Windows.Forms;

namespace LobbyLink.Desktop
{
    public partial class CreateItemInstanceForm : Form
    {
        private readonly ItemInstanceApiClient apiClient;

        public CreateItemInstanceForm(ItemInstanceApiClient apiClient)
        {
            InitializeComponent();
            this.apiClient = apiClient;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtItemDefinitionId.Text, out int itemDefinitionId))
                {
                    MessageBox.Show("ItemDefinitionId must be a valid number.");
                    return;
                }

                if (!int.TryParse(txtAccountId.Text, out int accountId))
                {
                    MessageBox.Show("AccountId must be a valid number.");
                    return;
                }

                ItemInstance itemInstance = new ItemInstance
                {
                    ItemDefinitionId = itemDefinitionId,
                    AccountId = accountId
                };

                int newId = apiClient.CreateItemInstance(itemInstance);

                MessageBox.Show($"ItemInstance created successfully. New ID: {newId}");

                txtItemDefinitionId.Clear();
                txtAccountId.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}