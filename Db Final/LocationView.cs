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
    public partial class LocationView : Form
    {
        public LocationView()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0]; // Get the first selected row
                int idToDelete = Convert.ToInt32(selectedRow.Cells["LocationId"].Value); // Assuming IdColumn is the column name containing the unique identifier

                // Execute SQL DELETE statement to delete the record with the specified id
                string deleteQuery = "DELETE FROM Location WHERE LocationId = @LocationId";
                var con = Configuration.getInstance().getConnection();

                SqlCommand command = new SqlCommand(deleteQuery, con);

                command.Parameters.AddWithValue("@LocationId", idToDelete);
                    command.ExecuteNonQuery();
                

                // Remove the selected row from the DataGridView
                guna2DataGridView1.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                using (var con = Configuration.getInstance().getConnection())
                {
                    DataGridViewRow editedRow = guna2DataGridView1.Rows[e.RowIndex];
                    int idToUpdate = Convert.ToInt32(editedRow.Cells["LocationId"].Value);
                    string newValue1 = Convert.ToString(editedRow.Cells["Country"].Value);
                    string newValue2 = Convert.ToString(editedRow.Cells["City"].Value);
                    string newValue3 = Convert.ToString(editedRow.Cells["Address"].Value);

                    string updateQuery = "UPDATE Location SET Country = @Country, City = @City, Address = @Address WHERE LocationId = @LocationId";

                    using (SqlCommand command = new SqlCommand(updateQuery, con))
                    {
                        command.Parameters.AddWithValue("@LocationId", idToUpdate);
                        command.Parameters.AddWithValue("@Country", newValue1);
                        command.Parameters.AddWithValue("@City", newValue2);
                        command.Parameters.AddWithValue("@Address", newValue3);

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void LocationView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            view();
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Location", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
