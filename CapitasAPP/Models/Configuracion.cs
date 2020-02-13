using System;
using System.Collections.Generic;
using System.Text;

namespace CapitasAPP.Models
{
    public class Configuracion
    {
        public int ID { get; set; }
        public decimal Capita { get; set; }
        public bool EnviarCorreo { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUserMail { get; set; }
        public string SmtpUserMailPassword { get; set; }

    }
}
