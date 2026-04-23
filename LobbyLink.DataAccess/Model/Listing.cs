namespace LobbyLink.DataAccess.Model;

public class Listing
{
    public int ListingId { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationTimeStamp { get; set; }

    // Foreign keys
    public int StatusId { get; set; }
    public ListingStatus? Status { get; set; }
    public int ItemInstanceId { get; set; }
    public ItemInstance? ItemInstance { get; set; }
    public int SellerAccountId { get; set; }
    public Account? SellerAccount { get; set; }
    public int? BuyerAccountId { get; set; }
    public Account? BuyerAccount { get; set; }

    public Listing() { } 
}


