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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            ShowStaff();
        }

        private void dsadasd_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StNameTb.Text = StaffList.SelectedRows[0].Cells[1].Value.ToString();
            PasswordTb.Text = StaffList.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = StaffList.SelectedRows[0].Cells[3].Value.ToString();
            AddressTb.Text = StaffList.SelectedRows[0].Cells[4].Value.ToString();
            GenderCb.Text = StaffList.SelectedRows[0].Cells[5].Value.ToString();
            StaffDOB.Text = StaffList.SelectedRows[0].Cells[6].Value.ToString();
            JDate.Text = StaffList.SelectedRows[0].Cells[7].Value.ToString();
            if (StNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StaffList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        Functions Fx = new Functions();
        private void ShowStaff()
        {
            string Query = "select  * from StaffTbl";
            DataSet ds = Fx.ShowData(Query);
            StaffList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            StNameTb.Text = "";
            PasswordTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
            GenderCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AddressTb.Text == " " || PhoneTb.Text == " " || StNameTb.Text == " " || PasswordTb.Text== "" || AddressTb.Text=="" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string StName = StNameTb.Text;
                string Password = PasswordTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                string Gender = GenderCb.Text;
                try
                {
                    string Query = "insert into StaffTbl values('" + StName + "','" + Password + "','" + Phone + "','"+Address+"','"+Gender+"','"+StaffDOB.Value.Date+"','"+JDate.Value.Date+"')";
                    Fx.SetData(Query, "Staff Inserted!!");
                    ShowStaff();
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (AddressTb.Text == " " || PhoneTb.Text == " " || StNameTb.Text == " " || PasswordTb.Text == "" || AddressTb.Text == "" || GenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!!");

            }
            else
            {
                string StName = StNameTb.Text;
                string Password = PasswordTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                string Gender = GenderCb.Text;
                try
                {
                    string Query = "Update StaffTbl set StName '" + StName + "',StPass '" + Password + "',StPhone'" + Phone + "',StAdd'" + Address + "',StGen '" + Gender + "',StDOB '" + StaffDOB.Value.Date + "',StJoin  '" + JDate.Value.Date + "' where StId "+Key+")";
                    Fx.SetData(Query, "Staff Updated!!");
                    ShowStaff();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Staff!!!");

            }
            else
            {
                try
                {
                    string Query = "Delete from StaffTbl where StId='" + Key + "'";
                    Fx.SetData(Query, "Stuff Deleted!!");
                    ShowStaff();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
