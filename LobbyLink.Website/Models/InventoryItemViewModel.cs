namespace LobbyLink.Website.Models;

public class InventoryItemViewModel
{
    public int ItemInstanceId { get; set; }
    public string? ItemName { get; set; }
    public string? Description { get; set; }
    public string? AccountOwner { get; set; }
    public string? GameTitle { get; set; }
    public bool IsListedForSale { get; set; }
}