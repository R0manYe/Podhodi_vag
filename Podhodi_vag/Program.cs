using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podhodi_vag
{
    class Program
    {
        static void Main(string[] args)
        {
            GoEtran ch = new GoEtran();
            var otv = ch.Proverka();
            Console.WriteLine(otv);
            if (otv == 0)
            {
              //  Dislokacia_ins pr = new Dislokacia_ins();
            //    pr.Rass();
                KOG_ins pr1 = new KOG_ins();
                pr1.Rass1();
               
            }
            else
            {

                string[] email1 = { "roman@abakan.vspt.ru" };
                DateTime parsedDate = DateTime.Now;

                foreach (string address in email1)
                {
                    string TextPisma = "неправильный ответ сервера на тест. C '" + parsedDate + "'";
                    string Zagolovok = "Не правильный ответ от АСУ при импорте ГУ2В ";
                    EmOpov opov1 = new EmOpov();
                    opov1.Opov_err(address, TextPisma, Zagolovok);
                }

            }
        }
    }
}
