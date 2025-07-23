using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDMVCproject.Models
{
    public class dBClass
    {
       public string constr = "Data Source=Rutuja\\SQLEXPRESS;Initial Catalog=empData;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

       public DataTable GetDataTable(string query)
        {
            //to get data
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;

        }

        public void executeNonQuery(string query)
        {
            //To Update, Insert and Delete Data-
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
