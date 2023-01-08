using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podhodi_vag
{
    class Ins_cli
    {
        public void cli()
        {
            string check_org = "select count(okpo) from(select distinct id_gruzotpr as okpo from dislokacia union select distinct id_gruzpol as okpo from dislokacia) " +
                "where okpo not in (select id from spr_etran_org)";            
            Sql_z sql_Z = new Sql_z();
            sql_Z.Oracle_v(check_org, out string vihod);
            int kol_org= Convert.ToInt16(vihod.ToString());
            if (kol_org>0)
            {
                for (int i = 1; i <= kol_org; i++)
                {
                    Console.WriteLine(i);
                    string Okpo = "select okpo from (select okpo,ROWNUM as numb from(select distinct id_gruzotpr as okpo from dislokacia union select distinct id_gruzpol as okpo from dislokacia) " +
                        "where okpo not in (select id from spr_etran_org)) where numb="+i+"";                   
                    sql_Z.Oracle_v(Okpo, out string vihod2);                  
                    create_zapros create_Zapros = new create_zapros();
                    string Org = create_Zapros.GreateOrg(vihod2, out string vihod3);
                    Sql_z sql_ZMS = new Sql_z();
                    string InsertTableSPREtranOrg = "DECLARE @x xml SET @x = '" + vihod3 + "' INSERT INTO [FLAGMAN]..[VSPTSVOD].[SPR_ETRAN_ORG]([ID],[INN],[OKPO],[KPP],[NAME],[SHORTNAME],[TYPE],[PASPORTSTATEID]," +
                       "[PASPORTSTATENAME],[ADDRESS],[PRIM],[DATE_INS]) (SELECT T.c.value('(orgID/@value)[1]', 'int') AS orgID, T.c.value('(orgINN/@value)[1]', 'varchar(20)') AS orgINN, " +
                       "T.c.value('(orgOKPO/@value)[1]', 'varchar(20)') AS orgOKPO, T.c.value('(orgKpp/@value)[1]', 'varchar(20)') AS orgKpp,T.c.value('(orgName/@value)[1]', 'varchar(100)') AS orgName," +
                       "T.c.value('(orgShortName/@value)[1]', 'varchar(500)') AS orgShortName,T.c.value('(orgType/@value)[1]', 'varchar(20)') AS orgType,T.c.value('(orgPasportStateID/@value)[1]', 'int') AS orgPasportStateID," +
                       "T.c.value('(orgPasportStateName/@value)[1]', 'varchar(20)') AS orgPasportStateName,T.c.value('(orgAddress/addressText/@value)[1]', 'varchar(500)') AS orgAddress,'Добавлен автоматически' as PRIM, GETDATE()  " +
                       "FROM @x.nodes('/getOrgPassportReply/org') T(c))";
                    sql_ZMS.Mssql_v(InsertTableSPREtranOrg);
                }
            }
            else
            {
                Console.WriteLine("Нечего загонять в справочник SPR_ETRAN_ORG");
            }

        }
    }
}
