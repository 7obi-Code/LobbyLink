using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;

public class Listing
{
    public decimal Price { get; set; }

    public required ItemInstance ItemInstance { get; set; }

    public required Account Account { get; set; }

}
