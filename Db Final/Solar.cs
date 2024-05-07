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
    public partial class Solar : Form
    {
        int Id;
        public Solar(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Solar_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Enter Required Records");
            }
            else
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd = new SqlCommand("Insert into Solar values (@LocationId, @NumberOfPlates)", con);
                    cmd.Parameters.AddWithValue("@LocationId", Id);
                    cmd.Parameters.AddWithValue("@NumberOfPlates", int.Parse(guna2TextBox1.Text));


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully saved");

                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    SqlCommand cmmd = new SqlCommand("Insert into Inverter values (@LocationId, @Reading, GETDATE())", con);
                    cmmd.Parameters.AddWithValue("@LocationId", Id);
                    cmmd.Parameters.AddWithValue("@Reading", randomNumber);
                    cmmd.ExecuteNonQuery();

                }
                catch(Exception ex)
                {

                }

                



            }
            //view();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";

            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }
    }
}
