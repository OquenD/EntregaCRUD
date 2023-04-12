using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDSqlite.Models
{
     public class Student
    {
        [PrimaryKey,AutoIncrement]
        public int IdStudent { get; set; }
        [MaxLength(50)]

        public string Name { get; set; }
        [MaxLength(50)]

        public string LastName { get; set; }
        [MaxLength(50)]

        public int Age { get; set; }
        [MaxLength(50)]

        public string Email { get; set; }
        
    }
}
