﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitasAPP.Models
{
    [Table("Capitas")]
    public class Capitas
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IdPersona { get; set; } 
        public decimal Enero { get; set; }
        public decimal Febrero { get; set; }
        public decimal Marzo { get; set; }
        public decimal Abril { get; set; }
        public decimal Mayo { get; set; }
        public decimal Junio { get; set; }
        public decimal Julio { get; set; }
        public decimal Agosto { get; set; }
        public decimal Septiembre { get; set; }
        public decimal Octubre { get; set; }
        public decimal Noviembre { get; set; }
        public decimal Diciembre { get; set; }        

    }
}
