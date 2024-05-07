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
    public partial class login : Form
    {
        int LId;
        string Cnic;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Customer();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" )
            {

                var con = Configuration.getInstance().getConnection();

                
                SqlCommand cmd = new SqlCommand("Select LocationId from Customers where CNIC = @CNIC and Password= @Password ", con);
                cmd.Parameters.AddWithValue("@CNIC", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text);
                object result = cmd.ExecuteScalar();
                Cnic = guna2TextBox1.Text;


                if (result != null)
                {
                    LId = int.Parse(result.ToString());
                    
                    Form moreForm = new Bill(LId,  Cnic);
                    this.Hide();
                    moreForm.Show();
                }
                else
                {
                    MessageBox.Show("No Record Exists");
                }
            }
            else
            {
                MessageBox.Show("Enter The Required Information");
            }

            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

           
        }
    }
}
