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
    public partial class MeterReading : Form
    {
        public MeterReading()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int idTo=0;
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0]; // Get the first selected row
                idTo= Convert.ToInt32(selectedRow.Cells["MeterId"].Value); // Assuming IdColumn is the column name containing the unique identifier

            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" )
            {
                MessageBox.Show("Enter Required Records");
                
            }
            else
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("Insert into MeterReading values ( @MeterId,@Units,@UnitOfMeasurment, @PricePerUnit, GETDATE())", con);
                cmd.Parameters.AddWithValue("@MeterId", idTo);
                cmd.Parameters.AddWithValue("@Units", int.Parse(guna2TextBox1.Text));
                cmd.Parameters.AddWithValue("@UnitOfMeasurment", "KWH");
                cmd.Parameters.AddWithValue("@PricePerUnit",int.Parse(guna2TextBox2.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");



            }
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
        }

        private void MeterReading_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from Meter", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
        }
    }
}
