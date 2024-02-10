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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            ShowCustomers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Number_TextChanged(object sender, EventArgs e)
        {

        }
        Functions Fx = new Functions();
        private void ShowCustomers()
        {
            string Query = "select  * from CustomerTbl";
            DataSet ds = Fx.ShowData(Query);
            CustomerList.DataSource = ds.Tables[0];
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (NumberTb.Text == " " || BrandCb.Text == " " || DescpTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Number = NumberTb.Text;
                string Brand = BrandCb.Text;
                string Description = DescpTb.Text;
                try
                {
                    string Query = "insert into CustomerTbl values('" + Number + "','" + Brand + "','" + Description + "')";
                    Fx.SetData(Query, "Customer Inserted!!");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void SuppliersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NumberTb.Text = CustomerList.SelectedRows[0].Cells[1].Value.ToString();
            BrandCb.Text = CustomerList.SelectedRows[0].Cells[2].Value.ToString();
            DescpTb.Text = CustomerList.SelectedRows[0].Cells[3].Value.ToString();
            if (NumberTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Customer!!!");

            }
            else
            {
                try
                {
                    string Query = "Delete from CustomerTbl where CId='" + Key + "'";
                    Fx.SetData(Query, "Customer Removed!!");
                    ShowCustomers();
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
            if (NumberTb.Text == " " || BrandCb.Text == " " || DescpTb.Text == " ")
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string Number = NumberTb.Text;
                string Brand = BrandCb.Text;
                string Description = DescpTb.Text;
                try
                {
                    string Query = "update CustomerTbl set Number = " + Number + ", Brand='" + Brand + "',Description='" + Description + "'where CId='" + Key + "'";
                    Fx.SetData(Query, "Customer updated!!");
                    ShowCustomers();
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
            NumberTb.Text = "";
            Key = 0;
            BrandCb.Text = "";
            DescpTb.Text = "";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
    }
}
