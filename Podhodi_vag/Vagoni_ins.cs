using System;
using System.Collections.Generic;
using System.Data;
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
    //Заполнение справочника вагонов SPR_ETRAN_VAGON
    class Vagoni_ins
    {
        string pr { get; set; }
        public void Vagoni()
        {
            string kol1 = "select ceil((count(nom_vag)/400)) as kol from dislokacia  where nom_vag not in (select vagon from spr_etran_vagon)";
            string vag_col = "select COUNT(*) as vag from dislokacia  where nom_vag not in (select vagon from spr_etran_vagon)";

            using (OracleConnection conn = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans;Unicode=True"))
            {
                OracleCommand command = new OracleCommand(kol1, conn);
                OracleCommand command1 = new OracleCommand(vag_col, conn);
                conn.Open();
                OracleDataReader thiskol1 = command.ExecuteReader();
                OracleDataReader thisvk = command1.ExecuteReader();
                while (thisvk.Read())
                {
                    string gg = thisvk.GetValue(0).ToString();
               //     Console.WriteLine(gg);
                    if (Convert.ToInt16(gg) > 0)
                    {
                        while (thiskol1.Read())
                        {
                            string ggg = thiskol1.GetValue(0).ToString();
                            if (thiskol1.GetValue(0).ToString() != String.Empty)
                            {
                                int ii = Convert.ToInt16(thiskol1.GetValue(0).ToString());

                                for (int i = 1; i <= ii; i++)
                                {
                                    DataSet ds = new DataSet();
                                    string vag = "select * from [dbo].[nom_vag1]";
                                    using (SqlConnection con = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533;Connection Timeout = 6000"))
                                    {
                                        SqlCommand command2 = new SqlCommand(vag, con);
                                        con.Open();
                                        SqlDataAdapter nvag = new SqlDataAdapter(vag, con);

                                        nvag.Fill(ds);
                                        string vagon = ds.Tables[0].Rows[0][0].ToString();
                                        con.Close();
                                        create_zapros Zap = new create_zapros();
                                        string rez_z = Zap.Vagoni(in vagon,pr);
                                        File.WriteAllText("vag.xml", rez_z);
                                      //  const string inputXMLFile = "ott10.xml";
                                        var xml = XElement.Parse(rez_z.ToString());
                                      //  var elem = XElement.Parse(xml.Value.Trim());
                                        string code3 = Regex.Replace(xml.ToString(), @"[\u0000-\u0008,\u000B,\u000C,\u000E-\u001F]", "");
                                        string code1 = code3.Replace("'", "");
                                      //  Console.WriteLine(code1);

                                        string stroka = " DECLARE @x xml SET @x = '" + code1.ToString() + "' " +
                                            "INSERT INTO[FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_VAGON]" +
                                            "([DATA_INS],[VAGON],[CARNSIDATE],[CARRESPONSE],[CARTYPEID],[CARTYPECODE],[CARTYPENAME],[CARAXLES],[CAROWNERCOUNTRYCODE],[CAROWNERCOUNTRYNAME],[CAROWNERTYPEID]," +
                                            "[CAROWNERTYPENAME],[CAROWNERID],[CAROWNEROKPO],[CAROWNERNAME],[CARTONNAGE],[CARWEIGHTDEP],[CARTANKTYPE],[CARVOLUME],[CARARENDATORID],[CARARENDATOROKPO]" +
                                            ",[CARARENDATORNAME],[CARENDARENDADATE],[CARYEAR],[CARTYPEREPAIR],[CARNEXTREPAIR],[CARBANNED],[CARSIGN],[CARLENGTH],[CARRACE],[CARNORMA]" +
                                            ",[CARDATESOB],[CARMODEL],[CARCONSPARK],[CARTRUSTEDOPERATORID],[CARTRUSTEDOPERATOROKPO],[CARTRUSTEDOPERATOR],[CARKODS],[CARKODARNUM],[CARCN_SOBSTV_ID],[CARTYPEV]" +
                                            ",[CARMODEL_CODE],[CARPR_K],[CARPR_K_NAME])" +
                                            "(SELECT GETDATE(), " +
                                            "T.c.value('(carNumber/@value)[1]', 'varchar(20)') AS carNumber," +
                                            "T.c.value('(carNSIDate/@value)[1]', 'varchar(20)') AS carNSIDate," +
                                            "T.c.value('(carResponse/@value)[1]', 'varchar(100)') AS carResponse," +
                                            "T.c.value('(carTypeID/@value)[1]', 'varchar(100)') AS carTypeID," +
                                            "T.c.value('(carTypeCode/@value)[1]', 'varchar(20)') AS carTypeCode," +
                                            "T.c.value('(carTypeName/@value)[1]', 'varchar(200)') AS carTypeName," +
                                            "T.c.value('(carAxles/@value)[1]', 'varchar(20)') AS carAxles," +
                                            "T.c.value('(carOwnerCountryCode/@value)[1]', 'varchar(20)') AS carOwnerCountryCode," +
                                            "T.c.value('(carOwnerCountryName/@value)[1]', 'varchar(200)') AS carOwnerCountryName," +
                                            "T.c.value('(carOwnerTypeID/@value)[1]', 'varchar(20)') AS carOwnerTypeID," +
                                            "T.c.value('(carOwnerTypeName/@value)[1]', 'varchar(20)') AS carOwnerTypeName," +
                                            "T.c.value('(carOwnerId/@value)[1]', 'varchar(20)') AS carOwnerId," +
                                            "T.c.value('(carOwnerOKPO/@value)[1]', 'varchar(200)') AS carOwnerOKPO," +
                                            "T.c.value('(carOwnerName/@value)[1]', 'varchar(200)') AS carOwnerName," +
                                            "T.c.value('(carTonnage/@value)[1]', 'varchar(5)') AS carTonnage," +
                                            "T.c.value('(carWeightDep/@value)[1]', 'varchar(20)') AS carWeightDep," +
                                            "T.c.value('(carTankType/@value)[1]', 'varchar(20)') AS carTankType," +
                                            "T.c.value('(carVolume/@value)[1]', 'varchar(20)') AS carVolume," +
                                            "T.c.value('(carArendatorID/@value)[1]', 'varchar(20)') AS carArendatorID," +
                                            "T.c.value('(carArendatorOKPO/@value)[1]', 'varchar(20)') AS carArendatorOKPO," +
                                            "T.c.value('(carArendatorName/@value)[1]', 'varchar(200)') AS carArendatorName," +
                                            "T.c.value('(carEndArendaDate/@value)[1]', 'varchar(40)') AS carEndArendaDate," +
                                            "T.c.value('(carYear/@value)[1]', 'varchar(20)') AS carYear," +
                                            "T.c.value('(carTypeRepair/@value)[1]', 'varchar(40)') AS carTypeRepair," +
                                            "T.c.value('(carNextRepair/@value)[1]', 'varchar(40)') AS carNextRepair," +
                                            "T.c.value('(carBanned/@value)[1]', 'varchar(20)') AS carBanned," +
                                            "T.c.value('(carSign/@value)[1]', 'varchar(10)') AS carSign," +
                                            "T.c.value('(carLength/@value)[1]', 'varchar(20)') AS carLength," +
                                            "T.c.value('(carRace/@value)[1]', 'varchar(20)') AS carRace," +
                                            "T.c.value('(carNorma/@value)[1]', 'varchar(20)') AS carNorma," +
                                            "T.c.value('(carDateSob/@value)[1]', 'varchar(40)') AS carDateSob," +
                                            "T.c.value('(carModel/@value)[1]', 'varchar(20)') AS carModel," +
                                            "T.c.value('(carConsPark/@value)[1]', 'varchar(20)') AS carConsPark," +
                                            "T.c.value('(CARTRUSTEDOPERATORID/@value)[1]', 'varchar(20)') AS CARTRUSTEDOPERATORID," +
                                            "T.c.value('(CARTRUSTEDOPERATOROKPO/@value)[1]', 'varchar(20)') AS CARTRUSTEDOPERATOROKPO," +
                                            "T.c.value('(CARTRUSTEDOPERATOR/@value)[1]', 'varchar(20)') AS CARTRUSTEDOPERATOR," +
                                            "T.c.value('(carKODS/@value)[1]', 'varchar(20)') AS carKODS," +
                                            "T.c.value('(carKODARNUM/@value)[1]', 'varchar(20)') AS carKODARNUM," +
                                            "T.c.value('(carCN_SOBSTV_ID/@value)[1]', 'varchar(20)') AS carCN_SOBSTV_ID," +
                                            "T.c.value('(carTYPEV/@value)[1]', 'varchar(20)') AS carTYPEV," +
                                            "T.c.value('(carMODEL_CODE/@value)[1]', 'varchar(20)') AS carMODEL_CODE," +
                                            "T.c.value('(carPR_K/@value)[1]', 'varchar(20)') AS carPR_K," +
                                            "T.c.value('(carPR_K_NAME/@value)[1]', 'varchar(100)') AS carPR_K_NAME " +
                                            "FROM @x.nodes('/getCarNSIReply/car') T(c))";

                                        using (SqlConnection connection1 = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                                        {
                                            SqlCommand command3 = new SqlCommand(stroka, connection1);
                                            connection1.Open();
                                            SqlDataReader thisStroka2 = command3.ExecuteReader();
                                            connection1.Close();
                                        }
                                        string vg = "insert into spr_etran_log (data,col_z,cikl,spr) values (sysdate,'" + gg + "','" + ggg + "','vagoni')";
                                        string del_lish = "delete  from spr_etran_vagon where vagon not in (select nom_vag from DISLOKACIA)";
                                        using (OracleConnection conn3 = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans;Unicode=True"))
                                        {
                                            OracleCommand command4 = new OracleCommand(vg, conn);
                                            OracleCommand command5 = new OracleCommand(del_lish, conn);
                                            conn3.Open();
                                            OracleDataReader thisvg = command4.ExecuteReader();
                                            OracleDataReader thisdel = command5.ExecuteReader();
                                            conn3.Close();
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
