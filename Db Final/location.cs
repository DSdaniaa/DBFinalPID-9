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
    
    public partial class location : Form
    {
        int id;
        public location()
        {
            InitializeComponent();
        }

        private void location_Load(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("Insert into Location values (@Country,@City, @Address)", con);
                cmd.Parameters.AddWithValue("@Country", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@City", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@Address", guna2TextBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");

                SqlCommand cmmd = new SqlCommand("Select LocationId from Location where Country = @Country and City=@City and Address=@Address ", con);
                cmmd.Parameters.AddWithValue("@Country", guna2TextBox1.Text);
                cmmd.Parameters.AddWithValue("@City", guna2TextBox2.Text);
                cmmd.Parameters.AddWithValue("@Address", guna2TextBox3.Text);
                object result = cmmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    id = Convert.ToInt32(result);
                }

            }
            //view();
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            Form moreForm = new CustomerInfo(id);
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Customer();
            this.Hide();
            moreForm.Show();
        }
    }
}
