using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Podhodi_vag
{
    class Err_obr
    {
        public void Obrab(in int i)
        {
            const string inputXMLFile = "KOG11.xml";
            {
                XDocument xxdoc = XDocument.Load(inputXMLFile);

                {
                    File.WriteAllText("KOG12.xml", xxdoc.ToString());


                    foreach (XElement elem1 in xxdoc.Descendants("error").Descendants("errorMessage"))
                    {

                        string mail_er = elem1.ToString();
                        File.WriteAllText("KOG13.xml", elem1.ToString());
                        string address = "roman@abakan.vspt.ru";
                        string TextPisma = "Нет данных по станции " + i + "." + mail_er + "";
                        EmOpov pi = new EmOpov();
                        string Zagolovok = "Ответ АСУ-АСУ слишком мал";
                        pi.Opov_err(address, TextPisma, Zagolovok);
                    }
                }

            }
        }
    }
}
