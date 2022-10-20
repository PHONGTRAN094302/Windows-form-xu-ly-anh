using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApp_XULYANH
{
    class Modify
    {
        public Modify()
        {

        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        public DataTable DataTable(string query)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection sqlconnection = Connection.GetSqlConnection())
            {
                sqlconnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlconnection);
                dataAdapter.Fill(datatable);
                sqlconnection.Close();
            }
                return datatable;
        }
        public void command(NhanVien nhanVien , string query)
        {
            using (SqlConnection sqlconnection = Connection.GetSqlConnection())
            {
                sqlconnection.Open();
                sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.Parameters.Add("@MaNv", nhanVien.Manv);
                sqlCommand.Parameters.Add("@Anh", nhanVien.Anh);
                sqlCommand.ExecuteNonQuery();
                sqlconnection.Close();
            }
        }
    }
}
