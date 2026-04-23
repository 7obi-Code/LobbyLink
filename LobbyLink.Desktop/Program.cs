using LobbyLink.APIClient;
using LobbyLink.Desktop;

namespace LobbyLink.Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ItemInstanceApiClient apiClient = new ItemInstanceApiClient("https://localhost:7094/");
            Application.Run(new MainForm());
        }
    }
}