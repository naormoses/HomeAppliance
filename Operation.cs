using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAppliance
{
    class Operation
    {
        protected SqlConnection getCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-SOV22BI\SQLEXPRESS;Initial Catalog=HomeApplianceDb;Integrated Security=True";
            return Con;
        }

        public void insertData(string query)
        {
            SqlConnection Con = getCon();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product Added Successfuly!");
            Con.Close();
        }


        public void EditData(string query)
        {
            SqlConnection Con = getCon();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product Updated Successfuly!");
            Con.Close();
        }

        public void deleteProd(string query)
        {
            SqlConnection Con = getCon();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product Deleted Successfuly!");
            Con.Close();
        }

        public int count()
        {
            SqlConnection Con = getCon();
            string query = "select * from ProductTbl order by ID";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = query;

            SqlDataReader rdr = cmd.ExecuteReader();
            int id = 0;
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
            }
            id += 1;
            Con.Close();
            return id;
        }


        //method to display data in the datagridview
        public DataSet populate(String query)
        {
            SqlConnection Con = getCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
