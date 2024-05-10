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
    public partial class BillLogIn : Form
    {
        int LId;
        string Cnic;
        public BillLogIn()
        {
            InitializeComponent();
        }

        private void BillLogIn_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from view1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
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

                    Form moreForm = new Generate(LId, Cnic);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
