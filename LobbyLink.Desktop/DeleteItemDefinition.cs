using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LobbyLink.Desktop
{
    public partial class DeleteItemDefinition : Form
    {
        private readonly ItemDefinitionApiClient apiClient;

        public DeleteItemDefinition(ItemDefinitionApiClient apiClient)
        {
            InitializeComponent();
            this.apiClient = apiClient;

            LoadItemDefinitions();
        }

        private void LoadItemDefinitions()
        {
            try
            {
                var itemDefinitions = apiClient.GetAllItemDefinitions();
                dgvItemDefinitions.DataSource = itemDefinitions.ToList();

                dgvItemDefinitions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItemDefinitions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvItemDefinitions.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item definitions:\n{ex.Message}");
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemDefinitions.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item definition.");
                    return;
                }

                var selectedItem = (ItemDefinition)dgvItemDefinitions.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show(
                    $"Delete item definition ID {selectedItem.ItemDefinitionId}?",
                    "Confirm",
                    MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    apiClient.DeleteItemDefinition(selectedItem.ItemDefinitionId);

                    MessageBox.Show("ItemDefinition deleted",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None);

                    LoadItemDefinitions(); // refresh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item definition:\n{ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}