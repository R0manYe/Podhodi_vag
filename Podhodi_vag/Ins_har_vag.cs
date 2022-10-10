using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Podhodi_vag
{
    class Ins_har_vag
    {
        //Добавление харктеристик вагонов
        string pr { get; set; }
        public void Vstavka_vag_har()
        {
            using (SqlConnection connection1 = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
            {

                string vag_har = "SELECT replace(replace((SELECT  f1 + char(10) FROM (SELECT  {fn CONCAT({ fn CONCAT('<vagon>', NAIM) }, '</vagon>') } AS f1 " +
                    "FROM[VSPTSVOD]..[VSPTSVOD].[SPR_COLLECTION] WHERE[ID_SPR] in ('VAG_KOG')) AS dd FOR xml path('')), '&lt;', '<'), '&gt;', '>') AS nom_vag";
                SqlCommand command = new SqlCommand(vag_har, connection1);
                connection1.Open();
                SqlDataReader vag_h = command.ExecuteReader();
                vag_h.Read();
                string ss = vag_h.GetValue(0).ToString();
                Console.WriteLine(ss);
                create_zapros Zap = new create_zapros();
                string rez_z = Zap.Vag_har(in ss, pr);
                if (rez_z.Length > 1577)
                {
                    const string inputXMLFile = "ott99.xml";
                    {
                        XDocument xxdoc = XDocument.Load(inputXMLFile);
                        XDocument realDoc = XDocument.Parse(xxdoc.Descendants("ASOUPReply").FirstOrDefault().Value);
                        File.WriteAllText("vag_har2.xml", realDoc.ToString());
                        foreach (XElement elem1 in realDoc.Descendants("referenceSPV4666"))
                            if (elem1.ToString().Length > 1000)
                            {
                                File.WriteAllText("vag_har3.xml", elem1.ToString());
                                string del_har_vag = "DELETE FROM [FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_VAGON_HAR]";
                                string ins_har_vag = "DECLARE @x xml SET @x = '" + elem1 + "' " +
                               "INSERT INTO [FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_VAGON_HAR]" +
            " ([NOM_VAG],[SOB],[NAIM_SOB],[DATE_POST],[KOD_PL_REM],[NAIM_KOD_PL_REM],[DATE_PL_REM],[DATE_VV_DAN],[KOD_VRAB],[NAIM_KOD_REM],[DOR_REM],[NAIM_DOR_REM],[DEPO_REM],[NAIM_DEPO_REM],[NEIS1]" +
            " ,[NAIM_NEIS1],[NEIS2],[NAIM_NEIS2],[NEIS3],[NAIM_NEIS3],[DATE_NEISP],[DATE_NACH_REM],[DATE_VIVOD],[STAN_OP],[NAIM_STAN_OP],[NOM_VU_23],[NOM_VU_36],[KOD_MOD1],[NAIM_KOD_MOD1],[KOD_MOD2]" +
            " ,[NAIM_KOD_MOD2],[KOD_MOD3],[NAIM_KOD_MOD3],[KOD_MOD4],[NAIM_KOD_MOD4],[KOD_MOD5],[NAIM_KOD_MOD5],[KOD_MOD6],[NAIM_KOD_MOD6],[KOD_MOD7],[NAIM_KOD_MOD7],[KOD_MOD8],[NAIM_KOD_MOD8],[KOD_MOD9]" +
            " ,[NAIM_KOD_MOD9],[KOD_MOD10],[NAIM_KOD_MOD10],[SOST_VAG],[NAIM_SOST_VAG]) " +
            " select T.c.value('(NOM_VAG)[1]', 'varchar(10)') AS NOM_VAG, T.c.value('(SOB)[1]', 'varchar(10)') AS SOB, T.c.value('(NAIM_SOB)[1]', 'varchar(10)') AS NAIM_SOB, T.c.value('(DATE_POST)[1]', 'date') AS DATE_POST," +
            " T.c.value('(KOD_PL_REM)[1]', 'int') AS KOD_PL_REM, (SELECT [NAIM] FROM [VSPTSVOD]..[VSPTSVOD].[SPR_COLLECTION] where [id_spr]='VAG_REM' and [SV]=(T.c.value('(KOD_PL_REM)[1]', 'int'))) AS NAIM_KOD_PL_REM, T.c.value('(DATE_PL_REM)[1]', 'date') AS DATE_PL_REM, T.c.value('(DATE_VV_DAN)[1]', 'date') AS DATE_VV_DAN," +
            " T.c.value('(KOD_VRAB)[1]', 'int') AS KOD_VRAB, T.c.value('(NAIM_KOD_REM)[1]', 'varchar(80)') AS NAIM_KOD_REM, T.c.value('(DOR_REM)[1]', 'int') AS DOR_REM, T.c.value('(NAIM_DOR_REM)[1]', 'varchar(80)') AS NAIM_DOR_REM," +
            " T.c.value('(DEPO_REM)[1]', 'int') AS DEPO_REM, T.c.value('(NAIM_DEPO_REM)[1]', 'varchar(100)') AS NAIM_DEPO_REM, T.c.value('(NEIS1)[1]', 'int') AS NEIS1, T.c.value('(NAIM_NEIS1)[1]', 'varchar(100)') AS NAIM_NEIS1," +
            " T.c.value('(NEIS2)[1]', 'int') AS NEIS2, T.c.value('(NAIM_NEIS2)[1]', 'varchar(100)') AS NAIM_NEIS2, T.c.value('(NEIS3)[1]', 'int') AS NEIS3, T.c.value('(NAIM_NEIS3)[1]', 'varchar(100)') AS NAIM_NEIS3," +
            " T.c.value('(DATE_NEISP)[1]', 'date') AS DATE_NEISP, T.c.value('(DATE_NACH_REM)[1]', 'date') AS DATE_NACH_REM, T.c.value('(DATE_VIVOD)[1]', 'date') AS DATE_VIVOD, T.c.value('(STAN_OP)[1]', 'int') AS STAN_OP," +
            " T.c.value('(NAIM_STAN_OP)[1]', 'varchar(100)') AS NAIM_STAN_OP, T.c.value('(NOM_VU_23)[1]', 'int') AS NOM_VU_23, T.c.value('(NOM_VU_36)[1]', 'int') AS NOM_VU_36, T.c.value('(KOD_MOD1)[1]', 'int') AS KOD_MOD1," +
            " T.c.value('(NAIM_KOD_MOD1)[1]', 'varchar(100)') AS NAIM_KOD_MOD1, T.c.value('(KOD_MOD2)[1]', 'int') AS KOD_MOD2, T.c.value('(NAIM_KOD_MOD2)[1]', 'varchar(100)') AS NAIM_KOD_MOD2, T.c.value('(KOD_MOD3)[1]', 'int') AS KOD_MOD3," +
            " T.c.value('(NAIM_KOD_MOD3)[1]', 'varchar(100)') AS NAIM_KOD_MOD3, T.c.value('(KOD_MOD4)[1]', 'int') AS KOD_MOD4, T.c.value('(NAIM_KOD_MOD4)[1]', 'varchar(100)') AS NAIM_KOD_MOD4, T.c.value('(KOD_MOD5)[1]', 'int') AS KOD_MOD5," +
            " T.c.value('(NAIM_KOD_MOD5)[1]', 'varchar(100)') AS NAIM_KOD_MOD5, T.c.value('(KOD_MOD6)[1]', 'int') AS KOD_MOD6, T.c.value('(NAIM_KOD_MOD6)[1]', 'varchar(100)') AS NAIM_KOD_MOD6, T.c.value('(KOD_MOD7)[1]', 'int') AS KOD_MOD7," +
            " T.c.value('(NAIM_KOD_MOD7)[1]', 'varchar(100)') AS NAIM_KOD_MOD7, T.c.value('(KOD_MOD8)[1]', 'int') AS KOD_MOD8, T.c.value('(NAIM_KOD_MOD8)[1]', 'varchar(100)') AS NAIM_KOD_MOD8, T.c.value('(KOD_MOD9)[1]', 'int') AS KOD_MOD9," +
            " T.c.value('(NAIM_KOD_MOD9)[1]', 'varchar(100)') AS NAIM_KOD_MOD9, T.c.value('(KOD_MOD10)[1]', 'int') AS KOD_MOD10, T.c.value('(NAIM_KOD_MOD10)[1]', 'varchar(100)') AS NAIM_KOD_MOD10, T.c.value('(SOST_VAG)[1]', 'int') AS SOST_VAG," +
            "                                 T.c.value('(NAIM_SOST_VAG)[1]', 'varchar(100)') AS NAIM_SOST_VAG FROM @x.nodes('/referenceSPV4666/row') T(c)";
                                string log_har = "DECLARE @x xml SET @x = '" + elem1 + "' INSERT INTO [FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_LOG] (cikl,spr,DATA,col_z) select 1 as cikl,'spr_etran_vagon_har' as spr,getdate() as data,count(T.c.value('(NOM_VAG)[1]', 'varchar(10)')) AS col_z " +
                                                        " FROM @x.nodes('/referenceSPV4666/row') T(c)";
                                using (SqlConnection connection = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                                {

                                    SqlCommand command1 = new SqlCommand(del_har_vag, connection);
                                    SqlCommand command2 = new SqlCommand(ins_har_vag, connection);
                                    SqlCommand command3 = new SqlCommand(log_har, connection);
                                    connection.Open();
                                    SqlDataReader thisd = command1.ExecuteReader();
                                    connection.Close();
                                    connection.Open();
                                    SqlDataReader thisin = command2.ExecuteReader();
                                    connection.Close();
                                    connection.Open();
                                    SqlDataReader thislog = command3.ExecuteReader();
                                    connection.Close();
                                }
                            }
                    }
                }
            }


        }
    }
}
    
