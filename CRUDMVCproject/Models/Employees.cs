using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CRUDMVCproject.Models
{
    public class Employees
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public string gender { get; set; }
        public int managerid { get; set; }
        string query;

        dBClass dbClass = new dBClass();
        public DataTable List()
        {
            //To show employees list
            query = "SELECT E.*,(SELECT M.name FROM employees AS M WHERE M.id = E.managerid)AS managername FROM employees AS E ORDER BY E.id";
            DataTable dt = dbClass.GetDataTable(query);
            return dt;
        }

        public void InsertUpdate(string mode)
        {
            if(mode == "Insert")
            {
                query = "INSERT INTO employees(name, email, mobileno, gender, managerid) VALUES('" + name + "','" + email + "', '" + mobileno + "', '" + gender + "', '" + managerid + "')";
                //query += "'"+gender+"',"+managerid+")";
                dbClass.executeNonQuery(query);
            }
            else if(mode == "Update")
            {
                query = "UPDATE employees SET name='" + this.name + "',email='" +this.email + "', mobileno = '" + this.mobileno + "',";
                query += "gender = '" + this.gender + "', managerid = " + this.managerid + " WHERE id = " + this.id;
                dbClass.executeNonQuery(query);
                
            }
          
        }
        public void GetSingleValue(int id)
        {
            //To get single data in Form Field by id 
            query = "SELECT * FROM employees WHERE id=" + id;
            DataTable dt = dbClass.GetDataTable(query);
            DataRow dr = dt.Rows[0];
            this.name = dr["name"].ToString();
            this.email = dr["email"].ToString();
            this.mobileno = dr["mobileno"].ToString();
            this.gender = dr["gender"].ToString();
            this.managerid = int.Parse(dr["managerid"].ToString());
            this.id = int.Parse(dr["id"].ToString());

        }

        public void Delete(int id)
        {
            query = "DELETE FROM employees WHERE id ="+id;
            dbClass.executeNonQuery(query);
        }
    }
}
