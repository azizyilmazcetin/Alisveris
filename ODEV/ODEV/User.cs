using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class User
    {
        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public float Balance { get; set; }

        public User()
        {
        }

        public User(string name, string lastName, string nickName, string password, int id, int telephoneNumber, string eMail, string address)
        {
            this.Name = name;
            this.LastName = lastName;
            this.NickName = nickName;
            this.Password = password;
            this.Id = id;
            this.TelephoneNumber = telephoneNumber;
            this.Email = eMail;
            this.Address = address;
            this.IsAdmin = false;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nLast Name: {1} \nNick Name: {2} \nId: {3} \nTelephone Number: {4} \nEmail: {5} \nAddress: {6} \nBalance: {7} Lira", 
                this.Name, this.LastName, this.NickName, this.Id, this.TelephoneNumber, this.Email, this.Address, Math.Round(this.Balance, 2));
        }
    }
}
