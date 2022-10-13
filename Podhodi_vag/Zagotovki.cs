using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Podhodi_vag
{
    class Zagotovki
    {
        public void Zag()
        {
            int i = 888004;
            create_zapros zap_z = new create_zapros();
            string otv = zap_z.Zagot(in i, out string pr);
            const string inputXMLFile = "ott99.xml";
            string text1 = inputXMLFile.ToString();
            var xml = XElement.Parse(otv);
            string code3 = Regex.Replace(xml.ToString(), @"[\u0000-\u0008,\u000B,\u000C,\u000E-\u001F]", "");
            string code1 = code3.Replace("'", "");
            string del = "delete from ETRAN_ZAGOTOVKI";
            string ins_zagotovki = "DECLARE @x xml SET @x = '" + code1 + "' " +
            "INSERT INTO [FLAGMAN]..[VSPTSVOD].[ETRAN_ZAGOTOVKI] ([DOC_ID],[LAST_DATE],[DocDescription],[STATEID],[STATENAME],[DOCTYPEID],[TYPENAME],[FILEDCARDATE],[CARNUMBER],[STATIONID],[STATIONCODE],[STATIONNAME]," +
            "[TOSTATIONID],[TOSTATIONCODE],[TOSTATIONNAME],[DATE_INS])" +
            "(select T.c.value('(Document/DOC_ID)[1]', 'int') AS DOC_ID,T.c.value('(Document/Last_Date)[1]', 'varchar(26)') AS LAST_DATE," +
            "T.c.value('(Document/DocDescription)[1]', 'varchar(100)') AS DocDescription,T.c.value('(Document/DocState/StateId)[1]', 'int') AS StateId," +
            "T.c.value('(Document/DocState/StateName)[1]', 'varchar(40)') AS StateName,T.c.value('(Document/DocType/DocTypeId)[1]', 'int') AS DocTypeId," +
            "T.c.value('(Document/DocType/DocTypeName)[1]', 'varchar(40)') AS TypeName,T.c.value('(FiledCarDate)[1]', 'varchar(26)') AS FiledCarDate," +
            "T.c.value('(Car/carNumber)[1]', 'int') AS carNumber,T.c.value('(Station/StationId)[1]', 'int') AS StationId,T.c.value('(Station/StationCodeMod11)[1]', 'int') AS StationCode," +
            "T.c.value('(Station/StationName)[1]', 'varchar(100)') AS StationName,T.c.value('(ToStation/StationId)[1]', 'int') AS ToStationId,T.c.value('(ToStation/StationCodeMod11)[1]', 'int') AS ToStationCode," +
            "T.c.value('(ToStation/StationName)[1]', 'varchar(100)') AS ToStationName,CONVERT (date, GETDATE())  FROM @x.nodes('/invoiceFiledCarsReply/invoiceFiledCar') T(c))";
            if (code1.Length > 1000)
            {
                Sql_z sql = new Sql_z();
                sql.Oracle_v(del);
                sql.Mssql_v(ins_zagotovki);
            }


        }

    }
}

