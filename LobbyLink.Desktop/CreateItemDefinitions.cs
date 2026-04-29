using LobbyLink.APIClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LobbyLink.Desktop
{
    public partial class CreateItemDefinitions : Form
    {
        private readonly GameApiClient gameApiClient;
        private readonly ItemDefinitionsApiClient apiClient;

        public CreateItemDefinitions(ItemDefinitionsApiClient apiClient, GameApiClient gameApiClient)
        {
            InitializeComponent();
            this.apiClient = apiClient;
            this.gameApiClient = gameApiClient;

            LoadGames();
        }

        private void LoadGames()
        {
            var games = gameApiClient.GetAllGames();

            cmbGame.DataSource = games.ToList();
            cmbGame.DisplayMember = "GameTitle";
            cmbGame.ValueMember = "GameId";
            cmbGame.SelectedIndex = -1;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    MessageBox.Show("Item name is required.");
                    txtItemName.Focus();
                    return;
                }

                if (cmbGame.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a game.");
                    return;
                }

                // Create model
                var itemDefinition = new DataAccess.Model.ItemDefinition
                {
                    ItemName = txtItemName.Text,
                    ItemImageUrl = txtImageUrl.Text,
                    ItemDescription = txtDescription.Text,
                    GameId = Convert.ToInt32(cmbGame.SelectedValue)
                };

                // Call API
                int newId = apiClient.InsertItemDefinition(itemDefinition);

                MessageBox.Show($"ItemDefinition created\nID: {newId}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);

                // Reset form
                txtItemName.Clear();
                txtImageUrl.Clear();
                txtDescription.Clear();

                cmbGame.SelectedIndex = -1;

                txtItemName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
