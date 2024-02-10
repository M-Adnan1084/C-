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
    public partial class Machine : Form
    {
        public Machine()
        {
            InitializeComponent();
            GetFuel();
            ShowMachine();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Machine_Load(object sender, EventArgs e)
        {

        }
        Functions Fx = new Functions();
        private void GetFuel()
        {
            string Query = "select * from FuelTbl";
            string Col = "FId";
            Fx.FillCombo(Query, Col, FuelCb);
        }

        private void ShowMachine()
        {
            string Query = "select  * from MachineTbl";
            DataSet ds = Fx.ShowData(Query);
            MachineList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            DescTb.Text = "";
            CompCb.SelectedIndex = -1;
            FuelCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FuelCb.SelectedIndex == -1 || CompCb.SelectedIndex == -1 || DescTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Fuel  = FuelCb.SelectedValue.ToString();
                string Company = CompCb.SelectedItem.ToString();
                string Description = DescTb.Text;
                try
                {
                    string Query = "insert into MachineTbl values(" + Fuel + ",'" + Company + "','" + Description + "')";
                    Fx.SetData(Query, "Machine Added!!");
                    ShowMachine();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            } 
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (FuelCb.SelectedIndex == -1 || CompCb.SelectedIndex == -1 || DescTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Fuel = FuelCb.SelectedValue.ToString();
                string Company = CompCb.SelectedItem.ToString();
                string Description = DescTb.Text;
                try
                {
                    string Query = "update MachineTbl set Fuel = " + Fuel + ",Company=" + Company + ",Description='" + Description + "'where MId='" + Key + "'";
                    Fx.SetData(Query, "Fuel updated!!");
                    ShowMachine();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void MachineList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FuelCb.Text = MachineList.SelectedRows[0].Cells[1].Value.ToString();
            CompCb.Text = MachineList.SelectedRows[0].Cells[2].Value.ToString();
            DescTb.Text = MachineList.SelectedRows[0].Cells[3].Value.ToString();
            if (FuelCb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MachineList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Machine!!!");

            }
            else
            {
                try
                {
                    string Query = "Delete from MachineTbl where MId='" + Key + "'";
                    Fx.SetData(Query, "Machine Removed!!");
                    ShowMachine();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void FuelCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CompCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
    }
    
}
