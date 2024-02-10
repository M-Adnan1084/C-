using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolPumpManagementSystem2
{
    public partial class Supplies : Form
    {
        public Supplies()
        {
            InitializeComponent();
            ShowSuppliers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Functions Fx = new Functions();
        private void ShowSuppliers()
        {
            string Query = "select  * from SupplierTbl";
            DataSet ds = Fx.ShowData(Query);
            SuppliersList.DataSource = ds.Tables[0];
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AddressTb.Text == " " || PhoneTb.Text == " " || SupNameTb.Text == " ") 
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Supplier = SupNameTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                try
                {
                    string Query = "insert into SupplierTbl values('" + Supplier + "','" + Phone + "','" + Address + "')";
                    Fx.SetData(Query, "Supplier Inserted!!");
                    ShowSuppliers();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }



        }
        int Key = 0;
        private void SuppliersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SupNameTb.Text = SuppliersList.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = SuppliersList.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = SuppliersList.SelectedRows[0].Cells[3].Value.ToString();
            if(SupNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SuppliersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (AddressTb.Text == " " || PhoneTb.Text == " " || SupNameTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Supplier = SupNameTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                try
                {
                    string Query = "Update SupplierTbl set SupName = '" + Supplier + "',SupPhone='" + Phone + "',SupAdd='" + Address + "'where SupId='"+Key+"'";
                    Fx.SetData(Query, "Supplier updated!!");
                    ShowSuppliers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void Clear()
        {
            PhoneTb.Text = "";
            Key = 0;
            SupNameTb.Text = "";
            AddressTb.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Supplier!!!");

            }
            else
            {
                try
                {
                    string Query = "Delete from SupplierTbl where SupId='" + Key + "'";
                    Fx.SetData(Query, "Supplier Deleted!!");
                    ShowSuppliers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
    }
}
