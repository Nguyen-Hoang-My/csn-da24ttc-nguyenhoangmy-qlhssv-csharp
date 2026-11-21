using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    
    class ThaotacCSDL
    {
        SqlConnection sqlCon;

        public ThaotacCSDL()
        {
            string strCon = @"Data Source=localhost\SQLEXPRESS; Database=QLHSSV; " +
                            @"Integrated Security=True; TrustServerCertificate=True";
            sqlCon = new SqlConnection(strCon);
        }

        
        public DataTable execute(string sqlStr, params SqlParameter[] thamSo)
        {
            SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
            cmd.Parameters.AddRange(thamSo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);           
            return dt;
        }

        
        public int executeNonQuery(string sqlStr, params SqlParameter[] thamSo)
        {
            SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
            cmd.Parameters.AddRange(thamSo);
            try
            {
                sqlCon.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                sqlCon.Close();     
            }
        }
    }
}