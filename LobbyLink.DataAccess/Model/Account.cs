using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace LobbyLink.DataAccess.Model
{   public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Type { get; set; }

        public Account() {
        }

        public Account(int accountId, string name, string surname, DateTime birthday, string email, string phoneNo, string type)
        {
            AccountId = accountId;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Email = email;
            PhoneNo = phoneNo;
            Type = type;
        }
    }
}