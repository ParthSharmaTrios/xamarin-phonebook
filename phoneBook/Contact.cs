using System;
using SQLite;

namespace phoneBook
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int id{
            get;set;
        }

        public string name { get; set; }

        public string number { get; set; }
    
    
    }
}
