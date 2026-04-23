using LobbyLink.APIClient;

namespace LobbyLink.Desktop
{
    public partial class MainForm : Form
    {
        private readonly ItemInstanceApiClient apiClient;

        public MainForm()
        {
            InitializeComponent();
            apiClient = new ItemInstanceApiClient("https://localhost:7094/");
        }

        private void btnOpenCreateForm_Click(object sender, EventArgs e)
        {
            var form = new CreateItemInstanceForm();
            form.ShowDialog();
        }
    }
}