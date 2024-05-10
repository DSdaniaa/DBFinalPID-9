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
    public partial class Generate : Form
    {
        int Lid;
        string CNIC;
        public Generate(int id, string cnic)
        {
            InitializeComponent();
            Lid = id;
            CNIC = cnic;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new BillLogIn();
            this.Hide();
            moreForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form moreForm = new Bill(Lid, CNIC);
            this.Hide();
            moreForm.Show();
        }

        private void Generate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
