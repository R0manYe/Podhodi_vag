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
                Temp_Dislokacia_ins pr = new Temp_Dislokacia_ins();
                pr.Rass();
                Temp_KOG_ins pr1 = new Temp_KOG_ins();
                pr1.Rass1();
                Ins_Dislokacia ins = new Ins_Dislokacia();
                ins.Vstavka_Dislokacia();
              /*  Ins_har_vag vs = new Ins_har_vag();
                vs.Vstavka_vag_har();*/
                Vagoni_ins vag = new Vagoni_ins();
                vag.Vagoni();
                Zagotovki zag = new Zagotovki();
                zag.Zag();
                Ins_cli ins_Cli = new Ins_cli();
                ins_Cli.cli();

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
