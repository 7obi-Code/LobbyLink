using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFGameDao
    { 
        Game? GetGameByID (int id);
        IEnumerable<Game> GetAllGames (int id);    
    }
}
 