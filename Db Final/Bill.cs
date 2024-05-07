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
    public partial class Bill : Form
    {
        int Id, Units, per, Amount=0;
        List<int> meterIds = new List<int>();
        List<int> billIds = new List<int>();
        string date;



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            /*var con = Configuration.getInstance().getConnection();

            if (guna2ComboBox1.SelectedItem.ToString()=="January")
            {
                for (int s = 0; s < billIds.Count; s++)
                {


                    for (int i = 0; i < meterIds.Count; i++)
                    {
                        int meterId = meterIds[i];
                        SqlCommand c = new SqlCommand("Select  Units from MeterReading where  MeterId = @MeterId ", con);
                        c.Parameters.AddWithValue("@MeterId", meterId);
                        object r = c.ExecuteScalar();
                        Units = int.Parse(r.ToString());

                        SqlCommand cc = new SqlCommand("Select  PricePerUnit from MeterReading where  MeterId = @MeterId ", con);
                        cc.Parameters.AddWithValue("@MeterId", meterId);
                        object rr = cc.ExecuteScalar();
                        per = int.Parse(rr.ToString());

                        Amount = Amount + (Units * per);

                    }
                }

            }
            else if(guna2ComboBox1.SelectedItem.ToString() == "February")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "March")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "April")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "May")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "June")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "July")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "August")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "September")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "October")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "November")
            {

            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "December")
            {

            }*/

        }

        string CNIC, name, phone, country, city, address;
        public Bill(int L, string c)
        {
            InitializeComponent();
            Id = L;
            CNIC = c;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            /* string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
             foreach (string monthName in monthNames)
             {
                 guna2ComboBox1.Items.Add(monthName);
             }
 */
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

                SqlCommand cc = new SqlCommand("Select  PricePerUnit from MeterReading where  MeterId = @MeterId ", con);
                cc.Parameters.AddWithValue("@MeterId", meterId);
                object rr = cc.ExecuteScalar();
                per = int.Parse(rr.ToString());

                Amount = Amount + (Units * per);

            }

            label3.Text = CNIC;
            label4.Text = name;
            label5.Text = phone;
            label6.Text = country;
            label7.Text = city;
            label8.Text = address;
            label9.Text = Units.ToString();
            label10.Text = "$"+per.ToString();
            label21.Text = "Total Amount: $" + Amount.ToString();





            for (int i = 0; i < meterIds.Count; i++)
            {
                int meterId = meterIds[i];
                SqlCommand d = new SqlCommand("Insert into Bill values ( @MeterId,GETDATE(), @Amount,@IsPayed)", con);
                d.Parameters.AddWithValue("@MeterId", meterId);
                d.Parameters.AddWithValue("@Amount", Amount);
                d.Parameters.AddWithValue("@Ispayed", 0);
                d.ExecuteNonQuery();

                SqlCommand r = new SqlCommand("Select BillDate from Bill where  MeterId = @MeterId ", con);
                r.Parameters.AddWithValue("@MeterId", meterId);
                object l = r.ExecuteScalar();
                date = l.ToString();
            }
            label22.Text = "02-04-2024";








        }
    }
}
