using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Podhodi_vag
{
    class EmOpov
    {
       
            public void Opov_err(string address, string TextPisma, string Zagolovok)
            {

                DateTime parsedDate = DateTime.Now;
                SmtpClient Smtp = new SmtpClient("mail.vspt.org", 25);
                Smtp.EnableSsl = false;
                Smtp.Credentials = new System.Net.NetworkCredential("robot", "Abakan_mail18");      // Логин и пароль почты отправителя            
                MailMessage MyMessage = new MailMessage();
                MyMessage.From = new MailAddress("robot@abakan.vspt.ru");      // От кого отправляем почту
                MyMessage.To.Add(address);                       // Кому отправляем почту
                MyMessage.Subject = Zagolovok;          // Тема письма
                MyMessage.Body = " Здравтсвуйте! \n " +
                TextPisma;
                Smtp.Send(MyMessage);

            }



           



        }
    }
