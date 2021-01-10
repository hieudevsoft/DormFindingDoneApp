using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    public class User
    {
       
        public User(string _email, string _password, byte _isRemember)
        {
            this.Email = _email;
            this.Password = _password;
            this.isRemember = _isRemember;
        }
        public User() { }
        public String Email{get;set;}
        public String Password { get; set; }
        public byte isRemember { get; set; }


    }
}
