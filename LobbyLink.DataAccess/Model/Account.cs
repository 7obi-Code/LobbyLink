using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace LobbyLink.DataAccess.Model
{   public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }

        public Account() {}
    }
}