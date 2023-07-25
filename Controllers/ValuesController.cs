using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Web.UI;
using System.Web.Helpers;

namespace Proj.Controllers
{
    public class ValuesController : ApiController
    {
        //SqlConnection con = new SqlConnection(@"Data Source=SAWANT;Initial Catalog=Kiran;Integrated Security=true;");
        SqlConnection con = new SqlConnection(@"server=SAWANT; database=Kiran; Integrated Security=true;");
        //Get api/values
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }
        // GET api/values/5
        public string Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee where id = '" + id + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // POST api/values
        public string Post(string Name, int Age, string Address, string Email)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee(Name, Age, Address, Email) VALUES (@Name, @Age, @Address, @Email)", con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value= Address;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value= Email;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Records inserted with values as '" + Name + "','" + Age + "', '" + Address + "','" + Email + "')";
            }
            else
            {
                return "Try again. No data inserted.";
            }
        }

        // PUT api/values/5
        public string Put(int id, string Name, int Age, string Address, string Email)
        {
            SqlCommand cmd = new SqlCommand("Update Employee set Name= '" + Name + "',Age='" + Age + "',Address='" + Address + "',Email='" + Email + "' where id ='" + id + "' ", con);
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = Address;
            cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = Age;
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Records Updated with values as '" + Name + "','" + Age + "', '" + Address + "','" + Email + "')";
            }
            else
            {
                return "Try again. No data Updated.";
            }

        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from Employee where id = '" + id + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record deleted successfully with id as " + id;
            }
            else
            {
                return "Try again. No records deleted.";
            }
        }
    }
}
