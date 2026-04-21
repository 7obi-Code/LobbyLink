namespace LobbyLink.DataAccess.Model;

public class Listing
{
    public int ListingId { get; set; }

    public decimal Price { get; set; }

    public DateTime CreationTimeStamp { get; set; }

    public string Status { get; set; }



    // Foreign keys
    public int ItemInstanceId { get; set; }
    public int AccountId { get; set; }
    public required ItemInstance ItemInstance { get; set; }
    public required Account Account { get; set; }
}