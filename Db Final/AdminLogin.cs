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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {

               


                if (guna2TextBox1.Text== "123454321" && guna2TextBox2.Text=="ds123")
                {
                    

                    Form moreForm = new Admin();
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
