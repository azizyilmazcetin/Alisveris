using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class AdminUser : User
    {
        public AdminUser()
        {
        }

        public AdminUser(string name, string lastName, string nickName, string password, int id, int telephoneNumber, string eMail, string address)
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
        }
    }
}
