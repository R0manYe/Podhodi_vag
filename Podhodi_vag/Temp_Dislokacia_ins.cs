using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Podhodi_vag
{
    public class Temp_Dislokacia_ins
    {
        ///string pr { get; set; }
        public void Rass()
        {
            string del_temp_dis = "delete from temp_dislokacia";
            string del_temp_dis2 = "delete from temp_dislokacia2";
            Console.WriteLine("Чистим таблицы");

            using (OracleConnection conn1 = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans;Unicode=True"))
            {
                OracleCommand command = new OracleCommand(del_temp_dis, conn1);
                OracleCommand command1 = new OracleCommand(del_temp_dis2, conn1);
                conn1.Open();
                OracleDataReader ud1 = command.ExecuteReader();
                OracleDataReader ud2 = command1.ExecuteReader();
                conn1.Close();
            }

            int[] numbers = new int[] { 886808, 892103, 888305, 888004, 887500, 890703, 882309, 884003, 883809, 890108, 882506, 932103, 932207, 932300 };

            foreach (int i in numbers)
            {
                create_zapros Zapros = new create_zapros();
                string rez_z = Zapros.Dislokacia(in i, out string pr);
                {
                    if (rez_z.Length > 1577)
                    {
                        File.WriteAllText("ottt.xml", rez_z);
                        {                           
                                const string inputXMLFile = "ottt.xml";
                                {
                                    XDocument xxdoc = XDocument.Load(inputXMLFile);
                                    XDocument realDoc = XDocument.Parse(xxdoc.Descendants("ASOUPReply").FirstOrDefault().Value);
                                    File.WriteAllText("KOG66.xml", realDoc.ToString());
                                    foreach (XElement elem1 in realDoc.Descendants("referenceSPV4664"))
                                    {
                                        File.WriteAllText("KOG77.xml", elem1.ToString());

                                    //Допроверка на ошибки ответов АСУ-АСУ
                                    using (SqlConnection connection1 = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                                    {
                                        string proverka = "DECLARE @x xml SET @x = '" + elem1 + "' select count(T.c.value('(NOM_VAG)[1]', 'varchar(20)')) AS NOM_VAG FROM @x.nodes('/referenceSPV4664/row') T(c)";
                                        SqlCommand command = new SqlCommand(proverka, connection1);
                                        connection1.Open();
                                        SqlDataReader prov = command.ExecuteReader();
                                        prov.Read();
                                        int i_prov = Convert.ToInt16(prov.GetValue(0).ToString());
                                        if (i_prov > 0)
                                        {
                                            string log_kol_z = "DECLARE @x xml SET @x = '" + elem1 + "'INSERT INTO[FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_LOG] (ID_ST,cikl,spr,DATA,col_z)" +
                                            " select '" + i + "' as id_st,1 as cikl,'temp_dislokacia' as spr,GETDATE() as date, count(T.c.value('(NOM_VAG)[1]', 'varchar(20)')) as col_z FROM @x.nodes('/referenceSPV4664/row') T(c)";
                                            string inf = "DECLARE @x xml SET @x = '" + elem1 + "'" +
                        "INSERT INTO[FLAGMAN]..[VSPTSVOD].[TEMP_DISLOKACIA] (NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                        "GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP," +
                        "VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                        " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                        "NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                        "PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR) " +
                       " select T.c.value('(NOM_VAG)[1]', 'varchar(20)') AS NOM_VAG,T.c.value('(ROD_VAG_UCH)[1]', 'int') AS ROD_VAG_UCH,T.c.value('(KOD_SOB)[1]', 'int') AS KOD_SOB,T.c.value('(DATE_NACH)[1]', 'datetimeoffset') AS DATE_NACH," +
                       "T.c.value('(STAN_NACH)[1]', 'int') AS STAN_NACH,T.c.value('(DOR_NACH)[1]', 'int') AS DOR_NACH,T.c.value('(STR_NACH)[1]', 'int') AS STR_NACH,T.c.value('(STAN_NAZN)[1]', 'int') AS STAN_NAZN," +
                       "T.c.value('(DOR_NAZN)[1]', 'int') AS DOR_NAZN,T.c.value('(STR_NAZN)[1]', 'int') AS STR_NAZN,T.c.value('(GRUZPOL)[1]', 'int') AS GRUZPOL,T.c.value('(GRUZPOL_OKPO)[1]', 'varchar(20)') AS GRUZPOL_OKPO," +
                       "T.c.value('(GRUZOTPR)[1]', 'int') AS GRUZOTPR,T.c.value('(GRUZOTPR_OKPO)[1]', 'varchar(20)') AS GRUZOTPR_OKPO,T.c.value('(KOD_GRZ_GNG)[1]', 'varchar(12)') AS KOD_GRZ_GNG," +
                       "T.c.value('(PROB_GRJ)[1]', 'varchar(12)') AS PROB_GRJ,T.c.value('(PROB_POR)[1]', 'varchar(12)') AS PROB_POR,T.c.value('(OS_OTM1)[1]', 'int') AS OS_OTM1,T.c.value('(OS_OTM2)[1]', 'int') AS OS_OTM2," +
                       "T.c.value('(OS_OTM3)[1]', 'int') AS OS_OTM3,T.c.value('(VES_GRZ)[1]', 'int') AS VES_GRZ,T.c.value('(DATE_OP)[1]', 'datetime') AS DATE_OP,T.c.value('(DOR_RASCH)[1]', 'int') AS DOR_RASCH," +
                       "T.c.value('(STAN_OP)[1]', 'int') AS STAN_OP,T.c.value('(KOP_VMD)[1]', 'int') AS KOP_VMD,T.c.value('(KOP_PMD)[1]', 'int') AS KOP_PMD,T.c.value('(PPV_MEST)[1]', 'int') AS PPV_MEST," +
                       "T.c.value('(PPV_TRANZ)[1]', 'int') AS PPV_TRANZ,T.c.value('(PPV_POR)[1]', 'int') AS PPV_POR,T.c.value('(PPV_GRUJ)[1]', 'int') AS PPV_GRUJ,T.c.value('(PPV_NRP)[1]', 'int') AS PPV_NRP," +
                       "T.c.value('(PPV_RP)[1]', 'int') AS PPV_RP,T.c.value('(VNRP_NEISP)[1]', 'int') AS VNRP_NEISP,T.c.value('(VNRP_SPEC_TEX)[1]', 'int') AS VNRP_SPEC_TEX,T.c.value('(DOR_SDACH_GOS)[1]', 'int') AS DOR_SDACH_GOS," +
                       "T.c.value('(DOR_PRIEM_GOS)[1]', 'int') AS DOR_PRIEM_GOS,T.c.value('(INDEX_POEZD)[1]', 'varchar(40)') AS INDEX_POEZD,T.c.value('(NOM_POEZD)[1]', 'int') AS NOM_POEZD,T.c.value('(NPP_VAG)[1]', 'int') AS NPP_VAG," +
                       "T.c.value('(NOM_PARK)[1]', 'int') AS NOM_PARK,T.c.value('(NOM_PUT)[1]', 'int') AS NOM_PUT,T.c.value('(KOL_ZPU)[1]', 'int') AS KOL_ZPU,T.c.value('(KOL_GRJ_KONT)[1]', 'int') AS KOL_GRJ_KONT," +
                       "T.c.value('(KOL_POR_KONT)[1]', 'int') AS KOL_POR_KONT,T.c.value('(NOM_KON1)[1]', 'varchar(20)') AS NOM_KON1,T.c.value('(NOM_KON2)[1]', 'varchar(20)') AS NOM_KON2,T.c.value('(NOM_KON3)[1]', 'varchar(20)') AS NOM_KON3," +
                       "T.c.value('(NOM_KON4)[1]', 'varchar(20)') AS NOM_KON4,T.c.value('(NOM_KON5)[1]', 'varchar(20)') AS NOM_KON5,T.c.value('(NOM_KON6)[1]', 'varchar(20)') AS NOM_KON6,T.c.value('(NOM_KON7)[1]', 'varchar(20)') AS NOM_KON7," +
                       "T.c.value('(NOM_KON8)[1]', 'varchar(20)') AS NOM_KON8,T.c.value('(NOM_KON9)[1]', 'varchar(20)') AS NOM_KON9,T.c.value('(NOM_KON10)[1]', 'varchar(20)') AS NOM_KON10,T.c.value('(NOM_KON11)[1]', 'varchar(20)') AS NOM_KON11," +
                       "T.c.value('(NOM_KON12)[1]', 'varchar(20)') AS NOM_KON12,T.c.value('(NOM_KON13)[1]', 'varchar(20)') AS NOM_KON13,T.c.value('(ID_OTPRK)[1]', 'varchar(40)') AS ID_OTPRK,T.c.value('(NOM_NAK)[1]', 'varchar(40)') AS NOM_NAK," +
                       "T.c.value('(UNO)[1]', 'varchar(40)') AS UNO,T.c.value('(NOM_OTPRK_1)[1]', 'varchar(20)') AS NOM_OTPRK_1,T.c.value('(NOM_OTPRK_2)[1]', 'varchar(20)') AS NOM_OTPRK_2,T.c.value('(NOM_OTPRK_3)[1]', 'varchar(20)') AS NOM_OTPRK_3," +
                       "T.c.value('(NOM_OTPRK_4)[1]', 'varchar(20)') AS NOM_OTPRK_4,T.c.value('(NOM_OTPRK_5)[1]', 'varchar(20)') AS NOM_OTPRK_5,T.c.value('(NOM_OTPRK_6)[1]', 'varchar(20)') AS NOM_OTPRK_6," +
                       "T.c.value('(NOM_OTPRK_7)[1]', 'varchar(20)') AS NOM_OTPRK_7, T.c.value('(NOM_OTPRK_8)[1]', 'varchar(20)') AS NOM_OTPRK_8,T.c.value('(NOM_OTPRK_9)[1]', 'varchar(20)') AS NOM_OTPRK_9," +
                       "T.c.value('(NOM_OTPRK_10)[1]', 'varchar(20)') AS NOM_OTPRK_10,T.c.value('(NOM_OTPRK_11)[1]', 'varchar(20)') AS NOM_OTPRK_11,T.c.value('(NOM_OTPRK_12)[1]', 'varchar(20)') AS NOM_OTPRK_12," +
                       "T.c.value('(NOM_OTPRK_13)[1]', 'varchar(20)') AS NOM_OTPRK_13,T.c.value('(ID_OTPRK_DOSYL)[1]', 'varchar(40)') AS ID_OTPRK_DOSYL,T.c.value('(UNO_DOSYL)[1]', 'varchar(40)') AS UNO_DOSYL," +
                       "T.c.value('(DATE_DOSTAV)[1]', 'datetime') AS DATE_DOSTAV,T.c.value('(RASST_OB)[1]', 'varchar(40)') AS RASST_OB,T.c.value('(RASST_STAN_OP)[1]', 'varchar(40)') AS RASST_STAN_OP," +
                       "T.c.value('(RASST_STAN_NAZN)[1]', 'int') AS RASST_STAN_NAZN,T.c.value('(PROST_DN)[1]', 'int') AS PROST_DN,T.c.value('(PROST_CH)[1]', 'int') AS PROST_CH,T.c.value('(PROST_MIN)[1]', 'int') AS PROST_MIN," +
                       "T.c.value('(NORMA_KM)[1]', 'int') AS NORMA_KM,T.c.value('(OSTATOK)[1]', 'int') AS OSTATOK,T.c.value('(KOD_GRZ_VYGR)[1]', 'int') AS KOD_GRZ_VYGR,T.c.value('(PR_OST_GRZ)[1]', 'int') AS PR_OST_GRZ," +
                       "T.c.value('(DATE_OTPR)[1]', 'datetime') AS DATE_OTPR,T.c.value('(KOD_PL_OTPR)[1]', 'varchar(40)') AS KOD_PL_OTPR,T.c.value('(TARIF)[1]', 'varchar(40)') AS TARIF," +
                       "T.c.value('(OTM_GOD_VAG)[1]', 'int') AS OTM_GOD_VAG,T.c.value('(POROG_PROB)[1]', 'int') AS POROG_PROB,T.c.value('(PR_OTM)[1]', 'int') AS PR_OTM,T.c.value('(PR_STR)[1]', 'int') AS PR_STR," +
                       "T.c.value('(DATE_ZAP)[1]', 'datetime') AS DATE_ZAP,T.c.value('(KOD_GRZ_UCH)[1]', 'int') AS KOD_GRZ_UCH,T.c.value('(KDS_T)[1]', 'varchar(40)') AS KDS_T,T.c.value('(DVS_T)[1]', 'datetime') AS DVS_T," +
                       "T.c.value('(ID_GRUZPOL)[1]', 'varchar(40)') AS ID_GRUZPOL,T.c.value('(ID_GRUZOTPR)[1]', 'varchar(40)') AS ID_GRUZOTPR FROM @x.nodes('/referenceSPV4664/row') T(c)";

                                            using (SqlConnection connection = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                                            {
                                                try
                                                {
                                                    SqlCommand command1 = new SqlCommand(inf, connection) { CommandTimeout = 0 };
                                                    SqlCommand command2 = new SqlCommand(log_kol_z, connection);
                                                    connection.Open();

                                                    SqlDataReader thissha = command1.ExecuteReader();
                                                    connection.Close();
                                                    connection.Open();
                                                    SqlDataReader thislog = command2.ExecuteReader();
                                                    connection.Close();
                                                }
                                                catch(SqlException e)
                                                {
                                                    Console.WriteLine("Исключение!");
                                                    string address = "roman@abakan.vspt.ru";
                                                    string TextPisma = e.ToString();
                                                    EmOpov pi = new EmOpov();
                                                    string Zagolovok = "Исключение при заполнении TEMP_DISLOKACIA";
                                                    pi.Opov_err(address, TextPisma, Zagolovok);
                                                }
                                            }
                                            Console.WriteLine("Все по плану.Загоняем");
                                        }
                                        else
                                        {
                                           // Console.WriteLine("Исключение!");
                                            string address = "roman@abakan.vspt.ru";
                                            string TextPisma = "Нет данных по станции "+i+"";
                                            EmOpov pi = new EmOpov();
                                            string Zagolovok = "Ответ АСУ-АСУ слишком мал";
                                            pi.Opov_err(address, TextPisma, Zagolovok);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else if (rez_z.Length < 813)

                    {
                        if (i != 886808 && i != 890703)
                        {                          
                                var xml = XElement.Parse(rez_z);
                                var elem = XElement.Parse(xml.Value.Trim());
                                string code3 = Regex.Replace(elem.ToString(), @"[\u0000-\u0008,\u000B,\u000C,\u000E-\u001F]", "");
                                File.WriteAllText("KOG11.xml", code3.ToString());
                                Console.WriteLine(code3.Length);
                                string err = code3.ToString();
                                //  File.WriteAllText("KOG0802.xml", code3.ToString());
                                {
                                    const string inputXMLFile = "KOG11.xml";
                                    {
                                        XDocument xxdoc = XDocument.Load(inputXMLFile);

                                        {
                                            File.WriteAllText("KOG12.xml", xxdoc.ToString());

                                            //        foreach (XElement elem1 in xxdoc.Descendants("return").Descendants("errorMessage"))
                                            foreach (XElement elem1 in xxdoc.Descendants("error").Descendants("errorMessage"))
                                            {
                                             
                                               string mail_er = elem1.ToString();
                                                 File.WriteAllText("KOG13.xml", elem1.ToString());
                                                string address = "roman@abakan.vspt.ru";
                                                string TextPisma = "Нет данных по станции " + i + "."+mail_er+"";
                                                EmOpov pi = new EmOpov();
                                                string Zagolovok = "Ответ АСУ-АСУ слишком мал";
                                                pi.Opov_err(address, TextPisma, Zagolovok);
                                        }
                                        }

                                    }
                                }

                            }                         



                    else
                    {
                        if (i != 886808 && i != 890703)
                        {                           
                                var xml = XElement.Parse(rez_z);
                                var elem = XElement.Parse(xml.Value.Trim());
                                string code3 = Regex.Replace(elem.ToString(), @"[\u0000-\u0008,\u000B,\u000C,\u000E-\u001F]", "");
                                File.WriteAllText("KOG11.xml", code3.ToString());
                                Console.WriteLine(code3.Length);
                                string err = code3.ToString();
                               
                                {
                                    const string inputXMLFile = "KOG11.xml";
                                    {
                                        XDocument xxdoc = XDocument.Load(inputXMLFile);

                                        {
                                            File.WriteAllText("KOG12.xml", xxdoc.ToString());

                                            //        foreach (XElement elem1 in xxdoc.Descendants("return").Descendants("errorMessage"))
                                            foreach (XElement elem1 in xxdoc.Descendants("GetInformReply").Descendants("ASOUPReply").Descendants("return").Descendants("errorMessage"))
                                            {
                                             
                                                string mail_er = elem1.ToString();
                                                string address = "roman@abakan.vspt.ru";
                                                string TextPisma = "Нет данных по станции " + i + "." + mail_er + "";
                                                EmOpov pi = new EmOpov();
                                                string Zagolovok = "Ответ АСУ-АСУ слишком мал";
                                                pi.Opov_err(address, TextPisma, Zagolovok);
                                                File.WriteAllText("KOG14.xml", elem1.ToString());
                                            }
                                        }

                                    }
                                }

                            }


                          
                        }

                    }

                }
            }
                                             
        }
    }
}
 
