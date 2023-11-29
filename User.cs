using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem
{
    class User
    {

        private int id;
        public string username { get; set; }
        public string password { get; set; }
        public string role = "user";


        public int setId {
            set { this.id = value;  }
        }
        public User(string username, string password)
        {
           
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return $"{this.id} {this.username} {this.password} {this.role}";
        }
    }


}
