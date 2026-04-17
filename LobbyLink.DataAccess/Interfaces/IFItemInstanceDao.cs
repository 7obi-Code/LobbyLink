using LobbyLink.DataAccess.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemInstanceDao
    {
        IEnumerable<ItemInstance> GetAllItemInstancesByUserId();
        IEnumerable<ItemInstance> GetAllItemInstances();
    }
}
