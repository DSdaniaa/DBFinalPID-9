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

namespace Db_Final
{
    public partial class CustomerInfo : Form
    {
        int Id;
        public CustomerInfo(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
            {
                MessageBox.Show("Enter Required Records");
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
               
                SqlCommand cmd = new SqlCommand("Insert into Customers values (@LocationId, @CNIC,@Name, @PhoneNumber,@Password)", con);
                cmd.Parameters.AddWithValue("@LocationId", Id);
                cmd.Parameters.AddWithValue("@CNIC", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Name", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox4.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");

                

            }
            //view();
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            Form moreForm = new Meter(Id);
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
