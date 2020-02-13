using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CapitasAPP.Services
{
    public class MailService
    {
        public bool SendEmail(MailModel smtp)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smtp.SmtpMailFrom, smtp.SmtpMailFrom, Encoding.UTF8);
                mail.Subject = smtp.Subject;
                mail.Body = smtp.Body;
                mail.To.Add(smtp.SmtpMailTo);

                if (smtp.IsBodyHtml)
                {
                    mail.IsBodyHtml = true;
                }
                else
                {
                    mail.IsBodyHtml = false;
                }

                //copias               
                if (!string.IsNullOrEmpty(smtp.Cc))
                {
                    string[] files = smtp.Cc.Split(',');

                    foreach (var item in files)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            mail.CC.Add(item);
                        }
                    }
                }

                //valida si hay archivos
                if (!string.IsNullOrEmpty(smtp.FilesPath))
                {
                    string[] files = smtp.FilesPath.Split(';');

                    foreach (var item in files)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                            mail.Attachments.Add(new Attachment(item.Trim()));
                        }
                    }
                }

                //Configuracion del SMTP
                SmtpClient SmtpServer = new SmtpClient(smtp.SmtpServer);
                SmtpServer.Port = smtp.SmtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(smtp.SmtpUserMail, smtp.SmtpUserMailPassword);

                if (smtp.EnableSsl)
                {
                    SmtpServer.EnableSsl = true;
                }
                else
                {
                    SmtpServer.EnableSsl = false;
                }

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public class MailModel
        {
            public string SmtpServer { get; set; }
            public int SmtpPort { get; set; }
            public string SmtpUserMail { get; set; }
            public string SmtpUserMailPassword { get; set; }
            public string SmtpMailTo { get; set; }
            public string SmtpMailFrom { get; set; }
            public string Cc { get; set; } //se  separa correos con , ejmplo: admin@gmail.com,user@gmail.com
            public string Subject { get; set; }
            public string Body { get; set; }
            public string FilesPath { get; set; }
            public bool EnableSsl { get; set; }
            public bool IsBodyHtml { get; set; }
        }





    }
}
