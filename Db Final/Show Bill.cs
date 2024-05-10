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
    public partial class Show_Bill : Form
    {
        string CNIC, name, phone, country, city, address;
        int Id, Units, per, Amount = 0, Unit2=0, Per2=0;
        List<int> meterIds = new List<int>();
        List<int> billIds = new List<int>();
        string date;

        public Show_Bill()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();
        }

        private void Show_Bill_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("Select Name from Customers where CNIC = @CNIC and LocationId = @LocationId ", con);
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmd.Parameters.AddWithValue("@LocationId", Id);
            object result = cmd.ExecuteScalar();
            name = result.ToString();


            SqlCommand cmmd = new SqlCommand("Select PhoneNumber from Customers where CNIC = @CNIC and LocationId = @LocationId ", con);
            cmmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmmd.Parameters.AddWithValue("@LocationId", Id);
            object resultt = cmmd.ExecuteScalar();
            phone = resultt.ToString();



            SqlCommand cmmmd = new SqlCommand("Select Country from Location where  LocationId = @LocationId ", con);
            cmmmd.Parameters.AddWithValue("@LocationId", Id);
            object resulttt = cmmmd.ExecuteScalar();
            country = resulttt.ToString();



            SqlCommand cmdd = new SqlCommand("Select City from Location where  LocationId = @LocationId ", con);
            cmdd.Parameters.AddWithValue("@LocationId", Id);
            object rresult = cmdd.ExecuteScalar();
            city = rresult.ToString();



            SqlCommand cmddd = new SqlCommand("Select Address from Location where  LocationId = @LocationId ", con);
            cmddd.Parameters.AddWithValue("@LocationId", Id);
            object rrresult = cmddd.ExecuteScalar();
            address = rrresult.ToString();



            SqlCommand command = new SqlCommand("SELECT MeterId FROM Meter WHERE LocationId = @LocationId", con);
            command.Parameters.AddWithValue("@LocationId", Id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int meterId = int.Parse(reader["MeterId"].ToString());
                    meterIds.Add(meterId);
                }
            }


            for (int i = 0; i < meterIds.Count; i++)
            {
                int meterId = meterIds[i];
                SqlCommand c = new SqlCommand("Select  Units from MeterReading where  MeterId = @MeterId ", con);
                c.Parameters.AddWithValue("@MeterId", meterId);
                object r = c.ExecuteScalar();
                Units = int.Parse(r.ToString());
                Unit2 = Unit2 + Units;

                SqlCommand cc = new SqlCommand("Select  PricePerUnit from MeterReading where  MeterId = @MeterId ", con);
                cc.Parameters.AddWithValue("@MeterId", meterId);
                object rr = cc.ExecuteScalar();
                per = int.Parse(rr.ToString());
                Per2 = Per2 + per;

                Amount = Amount + (Units * per);

            }

            label3.Text = CNIC;
            label4.Text = name;
            label5.Text = phone;
            label6.Text = country;
            label7.Text = city;
            label8.Text = address;
            label9.Text = Unit2.ToString();
            label10.Text = "$" + Per2.ToString();
            label21.Text = "Total Amount: $" + Amount.ToString();
            label22.Text = "02-04-2024";





        }
    }
}
