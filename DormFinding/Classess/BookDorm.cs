using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    public class BookDorm
    {
        private string _email_owner;
        private string _email_user;
        private int _id_dorm;
        private int _state_dorm;


        public BookDorm(string email_owner, string email_user, int id_dorm, int state_dorm)
        {
            this.EmailOwner = email_owner;
            this.EmailUser = email_user;
            this.IdDorm = id_dorm;
            this.StateDorm = state_dorm;
       
        }

        public BookDorm()
        {
        }

        public string EmailOwner { get => _email_owner; set => _email_owner = value; }
        public string EmailUser { get => _email_user; set => _email_user = value; }
        public int IdDorm { get => _id_dorm; set => _id_dorm = value; }
        public int StateDorm { get => _state_dorm; set => _state_dorm = value; }
      
    }
}
