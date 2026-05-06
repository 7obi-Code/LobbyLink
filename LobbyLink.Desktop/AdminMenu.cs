using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SqlClient;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.Desktop
{
    public partial class AdminMenu : Form
    {
        private readonly ItemInstancesApiClient itemInstancesApiClient;
        private readonly AccountsApiClient accountsApiClient;
        private readonly ItemDefinitionsApiClient itemDefinitionsApiClient;
        private readonly GameApiClient gameApiClient;
        private readonly ListingApiClient listingApiClient;

        public AdminMenu()
        {
            InitializeComponent();

            itemInstancesApiClient = new ItemInstancesApiClient("https://localhost:7148/api/v1/iteminstances");
            accountsApiClient = new AccountsApiClient("https://localhost:7148/api/v1/account");
            itemDefinitionsApiClient = new ItemDefinitionsApiClient("https://localhost:7148/api/v1/itemdefinition");
            gameApiClient = new GameApiClient("https://localhost:7148/api/v1/game");
            listingApiClient = new ListingApiClient("https://localhost:7148/api/v1/listings");
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

        // Loader alle data til adminmenu for aktive artifakter til overview
        private void AdminMenu_Load(object sender, EventArgs e)
        {
            labelActiveListings.Text = $"Listings: {listingApiClient.GetAllActiveListings().Count()}";
            labelActiveUsers.Text = $"Users: {accountsApiClient.GetAllAccounts().Count()}";
            labelActiveItemInstances.Text = $"Instances: {itemInstancesApiClient.GetAllItemInstances().Count()}";
            labelActiveGames.Text = $"Games: {gameApiClient.GetAllGames().Count()}";
        }


    }
}