using LobbyLink.DataAccess.Model;

namespace LobbyLink.Website.Models;

public class MarketPlaceViewModel
{
    public IEnumerable<Listing> Listings { get; set; } = new List<Listing>();

    public string? Search { get; set; }

    public string? Game { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public string? Sort { get; set; }

    public List<string> GamesTitles { get; set; } = new();
}
