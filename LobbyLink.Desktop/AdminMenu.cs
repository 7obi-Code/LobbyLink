using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.Desktop
{
    public partial class AdminMenu : Form
    {
        private readonly ItemInstanceApiClient itemInstancesApiClient;
        private readonly AccountApiClient accountsApiClient;
        private readonly ItemDefinitionApiClient itemDefinitionsApiClient;
        private readonly GameApiClient gameApiClient;
        private readonly ListingApiClient listingApiClient;

        public AdminMenu()
        {
            InitializeComponent();

            itemInstancesApiClient = new ItemInstanceApiClient("https://localhost:8888/api/v1/iteminstances");
            accountsApiClient = new AccountApiClient("https://localhost:8888/api/v1/accounts");
            itemDefinitionsApiClient = new ItemDefinitionApiClient("https://localhost:8888/api/v1/itemdefinitions");
            gameApiClient = new GameApiClient("https://localhost:8888/api/v1/games");
            listingApiClient = new ListingApiClient("https://localhost:8888/api/v1/listings");
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
            labelActiveListings.Text = $"Listings: {listingApiClient.GetFilteredListings().Count()}";
            labelActiveUsers.Text = $"Users: {accountsApiClient.GetAllAccounts().Count()}";
            labelActiveItemInstances.Text = $"Instances: {itemInstancesApiClient.GetAllItemInstances().Count()}";
            labelActiveGames.Text = $"Games: {gameApiClient.GetAllGames().Count()}";
        }


    }
}