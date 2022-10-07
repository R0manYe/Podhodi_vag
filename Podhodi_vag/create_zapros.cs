﻿using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Podhodi_vag
{
    class create_zapros
    {
        //string pr { get; set; }
        public string Dislokacia(in int i,out string pr)
        {
    
                using (SqlConnection connection1 = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                {

                    string gruzpol = "SELECT    replace(replace((SELECT  f1 + char(10) FROM(SELECT        { fn CONCAT({ fn CONCAT('<gruzpol_okpo>', [okpo]) }, '</gruzpol_okpo>') } AS f1" +
                           " FROM VSPTSVOD..VSPTSVOD.SPR_CLI WHERE [ID_ST]='" + i + "' AND LEN(OKPO)>4 GROUP BY OKPO) AS dd FOR xml path('')), '&lt;', '<'), '&gt;', '>') AS f1";
                    SqlCommand command = new SqlCommand(gruzpol, connection1);
                    connection1.Open();
                    SqlDataReader grpol = command.ExecuteReader();
                    grpol.Read();
                    string ss = grpol.GetValue(0).ToString();
                    string sborn =
                    "<GetInform>" +
                    "<ns0:getReferenceSPV4664 xmlns:ns0='http://service.siw.pktbcki.rzd/'>" +
                    "<ns0:ReferenceSPV4664Request>" +
                    "<idUser>3</idUser>" +
                    "<idReference>14</idReference>" +
                    "<gruzpolOkpos>" +
                     ss +
                    "</gruzpolOkpos>" +
                    "<stanNazns>" +
                    "<stan_nazn>"
                    + i +
                    "</stan_nazn>" +
                    "</stanNazns>" +
                    "<idstr>01</idstr>" +
                    "</ns0:ReferenceSPV4664Request>" +
                    "</ns0:getReferenceSPV4664>" +
                    "</GetInform>";
                    connection1.Close();
                    Console.WriteLine(i);
                    File.WriteAllText("ss.xml", ss);
                    File.WriteAllText("ott22.xml", sborn);


                    GoEtran otv = new GoEtran();
                    
                    pr = otv.Parsing(sborn);
                    File.WriteAllText("ott.xml", pr);
                  //  Console.WriteLine("Проверка в Vstavka " + pr.Length);
                }
            
            return pr;
        }
        public string KOG(in int i, out string pr)
        {
            string sborn =
                   "<GetInform>" +
                  "<ns0:getReferenceSPV4664 xmlns:ns0='http://service.siw.pktbcki.rzd/'>" +
                   "<ns0:ReferenceSPV4664Request>" +
                   "<idUser>3</idUser>" +
                   "<idReference>14</idReference>" +
                   "<okpoSob>" + i +
                   "</okpoSob>" +
                   "<idstr>01</idstr>" +
                   "</ns0:ReferenceSPV4664Request>" +
                    "</ns0:getReferenceSPV4664>" +
                   "</GetInform>";               
                Console.WriteLine(i);              
                File.WriteAllText("ott88.xml", sborn);
                GoEtran otv = new GoEtran();
                pr = otv.Parsing(sborn);
                File.WriteAllText("ott99.xml", pr);   
           return pr;
        }



    }
}
