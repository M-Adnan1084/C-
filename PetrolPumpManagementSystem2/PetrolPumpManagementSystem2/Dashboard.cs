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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetFinance();
            //CountMachines();
            //CountSuppliers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
        Functions Fx = new Functions();
        private void CountSuppliers()
        {
            string Query = "select count(*) from SupplierTbl";
            Fx.GetData(Query, SupLbl);
            SupLbl.Text = SupLbl.Text + "  Suppliers";
        }
        private void CountMachines()
        {
            string Query = "select count(*) from MachineTbl";
            Fx.GetData(Query, MachineLbl);
            MachineLbl.Text = MachineLbl.Text + "  Machine";
        }




        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void GetFinance()
         {
             string Query = "select sum(Fprice) from FuelTbl";
             Fx.GetData(Query, FinanceLbl);
             FinanceLbl.Text = "Rs  " + FinanceLbl.Text;

         }
    }
}
