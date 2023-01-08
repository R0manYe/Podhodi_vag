using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podhodi_vag
{
    class Sql_z
    {
        public string vihod { get; set; }
        
        public string Oracle_v(in string stroka,out string vihod)
        {
            vihod = null;
            using (OracleConnection conn = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans"))
            {
                OracleCommand command = new OracleCommand(stroka, conn);
                conn.Open();
                OracleDataReader vivod = command.ExecuteReader();
               while(vivod.Read())
                { vihod = vivod.GetValue(0).ToString(); }
                conn.Close();
            }
            return vihod;

        }
        public void Oracle_v1(string stroka)
        {
            using (OracleConnection conn = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans"))
            {
                OracleCommand command = new OracleCommand(stroka, conn);
                conn.Open();
                OracleDataReader vivod = command.ExecuteReader();
                conn.Close();
            }

        }
        public void Mssql_v(string stroka)
        {
            using (SqlConnection connection1 = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
            {
                SqlCommand command3 = new SqlCommand(stroka, connection1);
                connection1.Open();
                SqlDataReader thisStroka2 = command3.ExecuteReader();
                connection1.Close();
            }


        }
    }
}
