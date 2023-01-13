using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.Models
{
    public class PacientModel
    {
        [PrimaryKey, AutoIncrement]
        public int PacientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Ignore]
        public string FullName => $"{FirstName} {LastName}";
    }
}