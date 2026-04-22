using LobbyLink.APIClient;
using System.Net.Http;

namespace LinkLobby.Desktop
{
    public partial class MainForm : Form
    {
        private ItemInstanceApiClient apiClient;
        public MainForm()
        {
            InitializeComponent();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7094/")
            };
            apiClient = new ItemInstanceApiClient(httpClient);
        }
    }
}
