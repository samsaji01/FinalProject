using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApp5
{
    class Connect
    {
        int id, salary;
        string name, desg;
        public SqlConnection con;
        public void dbconnect()
        {
            con = new SqlConnection("Data Source=LAPTOP-INRLANMT\\SQLEXPRESS;Initial Catalog=sam;Integrated Security=true");
            con.Open();
        }
        public DataTable showdata()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select * from employee", con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            return ds.Tables[0];
        }
        public int _id
        {
            get { return id; }
            set { id = value; }
        }
        public int _salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string _name
        {
            get { return name; }
            set { name = value; }
        }
        public string _desg
        {
            get { return desg; }
            set { desg = value; }
        }
        public int dbinsert()
        {
            SqlCommand cmd = new SqlCommand("insert into employee values('" + name + "','" + salary + "','" + desg + "')", con);
            int i=cmd.ExecuteNonQuery();
            return i;
                
        }
        public SqlDataReader retrievedata()
        {
            SqlCommand cmd = new SqlCommand("Select * from employee where id='" + id + "'", con);
                
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
        public int updatedata()
        {
           
            SqlCommand upd = new SqlCommand("update employee set name='"+name+"',salary='"+salary+"',designation='"+desg+"' where id='"+id+"'", con);
           int i= upd.ExecuteNonQuery();
            return i;
        }
        public int deletedata()
        {
            SqlCommand dlt = new SqlCommand("delete from employee where id='" + id + "'", con);
            int x = dlt.ExecuteNonQuery();
            return x;
        }
    }
    }

