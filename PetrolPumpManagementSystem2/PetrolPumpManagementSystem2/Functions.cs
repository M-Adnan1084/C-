using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolPumpManagementSystem2
{
    class Functions
    {
        protected SqlConnection getConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\PetrolPumpDbAdnan.mdf;Integrated Security=True;Connect Timeout=30";
            return Con;
        }
        //Dashboard
        public void GetData(string Query, Label Lbl)
        {
            SqlConnection Con = getConnection();
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Lbl.Text = dt.Rows[0][0].ToString();

        }
        

        //Fill ComboBox
        public void FillCombo(string Query,string Col,ComboBox Cb)
        {
            SqlConnection Con = getConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand(Query, Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add(Col, typeof(int));
            dt.Load(Rdr);
            Cb.ValueMember = Col;
            Cb.DataSource = dt;
            Con.Close();

        }

        internal void GetData(string query, object financeLbl)
        {
            throw new NotImplementedException();
        }

        //Funtions to display data from databse
        public DataSet ShowData(string Query)
        {
            SqlConnection Con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = Query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
       
        //Funtion to insert into the database
        public void SetData(string Query, string Msg)
        {
            SqlConnection Con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            Con.Close();

            MessageBox.Show(Msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
