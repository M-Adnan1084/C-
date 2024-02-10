using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolPumpManagementSystem2
{
    public partial class Fuel : Form
    {
        public Fuel()
        {
            InitializeComponent();
            GetFuel();
            ShowFuel();
        }
        int Key =0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FNameTb.Text = FuelList.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = FuelList.SelectedRows[0].Cells[2].Value.ToString();
            SupIdCb.Text = FuelList.SelectedRows[0].Cells[3].Value.ToString();
            if (FNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(FuelList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        Functions Fx = new Functions();
        private void GetFuel()
        {
            string Query = "select * from SupplierTbl";
            string Col = "SupId";
            Fx.FillCombo(Query,Col, SupIdCb);
        }
       
        private void ShowFuel()
        {
            string Query = "select  * from FuelTbl";
            DataSet ds = Fx.ShowData(Query);
            FuelList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            FNameTb.Text = "";
            PriceTb.Text = "";
            SupIdCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FNameTb.Text == " " || SupIdCb.SelectedIndex == -1 || PriceTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Name = FNameTb.Text;
                string Price = PriceTb.Text;
                string Supplier = SupIdCb.SelectedValue.ToString();
                try
                {
                    string Query = "insert into FuelTbl values('" + Name + "','" + Price + "','" + Supplier + "')";
                    Fx.SetData(Query, "Fuel Added!!");
                    ShowFuel();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Fuel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (FNameTb.Text == " " || SupIdCb.SelectedIndex == -1 || PriceTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Name = FNameTb.Text;
                string Price = PriceTb.Text;
                string Supplier = SupIdCb.SelectedValue.ToString();
                try
                {
                    string Query = "update FuelTbl set FName = '" + Name + "',FPrice=" + Price + ",FSupplier='" + Supplier+ "'where FId='" + Key + "'";
                    Fx.SetData(Query, "Fuel updated!!");
                    ShowFuel();
                    Clear();
                } 
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Fuel!!!");

            }
            else
            {
                try
                {
                    string Query = "Delete from FuelTbl where FId='" + Key + "'";
                    Fx.SetData(Query, "Fuel Removed!!");
                    ShowFuel();
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
