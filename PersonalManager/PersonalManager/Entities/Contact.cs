using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManager.Entities
{
    public class Contact
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
