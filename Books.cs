using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem
{
    class Books
    {
        private int id;
        public string bookName;
        public string description;


        public int setId
        {
            set { this.id = value; }
        }
        public Books(string bookName, string description)
        {
            this.bookName = bookName;
            this.description = description;
        }

        public override string ToString() {
            return $"{this.id} {this.bookName} {this.description}";
        }
    }
}
