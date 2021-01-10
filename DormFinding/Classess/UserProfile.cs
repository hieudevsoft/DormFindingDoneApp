using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    public class UserProfile
    {
        private string _email;
        private string _name;
        private string _date;
        private string _phone;
        private string _address;
        private string _hint;
        private byte _gender;
        private byte[] _avatar;

        public string Email { get => _email; set => _email = value; }
        public string Name { get => _name; set => _name = value; }
        public string Date { get => _date; set => _date = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public string Hint { get => _hint; set => _hint = value; }
        public byte Gender { get => _gender; set => _gender = value; }
        public byte[] Avatar { get => _avatar; set => _avatar = value; }

        public UserProfile(string email, string name, string date, string phone, string address, string hint, byte gender, byte[] avatar)
        {
            Email = email;
            Name = name;
            Date = date;
            Phone = phone;
            Address = address;
            Hint = hint;
            Gender = gender;
            Avatar = avatar;
            
        }

        public UserProfile()
        {
        }
    }
}
