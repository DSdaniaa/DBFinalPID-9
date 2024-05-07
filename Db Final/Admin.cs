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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Form moreForm = new LocationView();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            Form moreForm = new CustomerView();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form moreForm = new MeterVieww();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form moreForm = new InverterView();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form moreForm = new SolarView();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form moreForm = new MeterReading();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form moreForm = new BillLogIn();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
