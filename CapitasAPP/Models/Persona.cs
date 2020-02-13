using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitasAPP.Models
{
    [Table("Persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telfono { get; set; }
        public string Email { get; set; } 
    }
}
