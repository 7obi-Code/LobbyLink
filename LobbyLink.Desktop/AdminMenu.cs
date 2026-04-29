using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;

namespace LobbyLink.Desktop
{
    public partial class AdminMenu : Form
    {
        private readonly ItemInstancesApiClient itemInstancesApiClient;
        private readonly AccountsApiClient accountsApiClient;
        private readonly ItemDefinitionsApiClient itemDefinitionsApiClient;
        private readonly GameApiClient gameApiClient;

        public AdminMenu()
        {
            InitializeComponent();

            itemInstancesApiClient = new ItemInstancesApiClient("https://localhost:7148/api/v1/iteminstance");
            accountsApiClient = new AccountsApiClient("https://localhost:7148/api/v1/account");
            itemDefinitionsApiClient = new ItemDefinitionsApiClient("https://localhost:7148/api/v1/itemdefinition");
            gameApiClient = new GameApiClient("https://localhost:7148/api/v1/game");

        }

        private void BtnCreateItemInstance_Click(object sender, EventArgs e)
        {
            var form = new CreateItemInstances(itemInstancesApiClient);
            form.ShowDialog();
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            var form = new CreateAccounts(accountsApiClient);
            form.ShowDialog();
        }


        private void BtnCreateItemDefinition_Click(object sender, EventArgs e)
        {
            var form = new CreateItemDefinitions(itemDefinitionsApiClient, gameApiClient);
            form.ShowDialog();
        }

        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            var form = new DeleteAccount(accountsApiClient);
            form.ShowDialog();
        }

        private void BtnDeleteItemDefinition_Click(object sender, EventArgs e)
        {
            var form = new DeleteItemDefinition(itemDefinitionsApiClient);
            form.ShowDialog();
        }
    }
}