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
    public partial class Meter : Form
    {
        int Id;
        public Meter(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Meter_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" )
            {
                MessageBox.Show("Enter Required Records");
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
                for (int i = 0; i < int.Parse(guna2TextBox1.Text); i++)
                {
                    SqlCommand cmd = new SqlCommand("Insert into Meter values (@LocationId, GETDATE())", con);
                    cmd.Parameters.AddWithValue("@LocationId", Id);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Successfully saved");



            }
            //view();
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";

            Form moreForm = new Solar(Id);
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
