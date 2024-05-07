using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_Final
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form moreForm = new login();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form moreForm = new location();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
