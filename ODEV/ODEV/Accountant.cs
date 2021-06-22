using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class Accountant : User
    {
        public Accountant()
        {
        }

        public bool IsAccountant { get; set; }

        public Accountant(string name, string lastName, string nickName, string password, int id, int telephoneNumber, string eMail, string address)
        {
            this.Name = name;
            this.LastName = lastName;
            this.NickName = nickName;
            this.Password = password;
            this.Id = id;
            this.TelephoneNumber = telephoneNumber;
            this.Email = eMail;
            this.Address = address;
            this.IsAdmin = true;
            this.IsAccountant = true;
        }
    }
}
