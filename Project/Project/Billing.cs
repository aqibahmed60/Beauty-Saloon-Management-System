using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Finisar.SQLite;

namespace Project
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        public void display()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select * from Billing ";

            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlite_conn.Close();
        }


        private void Billing_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            MakeUp1 m1 = new MakeUp1();
            m1.ShowDialog();

            Billing B1 = new Billing();
            B1.ShowDialog();
        }

        private string s1;

        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox19.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Customer Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Billing where CustomerNo =" + textBox19.Text + " ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                s1 = textBox19.Text;

                if (sqlite_datareader.Read())
                {
                    textBox20.Text = sqlite_datareader.GetString(1);
                    textBox21.Text = sqlite_datareader.GetString(2);
                    textBox22.Text = sqlite_datareader.GetString(3);
                    textBox23.Text = sqlite_datareader.GetString(4);
                    textBox24.Text = sqlite_datareader.GetString(5);
                    textBox25.Text = sqlite_datareader.GetString(6);
                    textBox26.Text = sqlite_datareader.GetString(7);
                    textBox27.Text = sqlite_datareader.GetString(8);
                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if ((string.IsNullOrWhiteSpace(textBox19.Text)) || (string.IsNullOrWhiteSpace(textBox20.Text)) || (string.IsNullOrWhiteSpace(textBox21.Text)) || (string.IsNullOrWhiteSpace(textBox22.Text)) || (string.IsNullOrWhiteSpace(textBox23.Text)) || (string.IsNullOrWhiteSpace(textBox24.Text)) || (string.IsNullOrWhiteSpace(textBox25.Text)) || (string.IsNullOrWhiteSpace(textBox26.Text)) || (string.IsNullOrWhiteSpace(textBox27.Text)))
            {

                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (!int.TryParse(textBox19.Text, out parsedValue))
            {

                MessageBox.Show("Customer Number is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;

                sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");

                sqlite_conn.Open();


                sqlite_cmd = sqlite_conn.CreateCommand();

                string s3 = Convert.ToString(textBox19.Text);
                string s4;

                if (s3 != s1)
                {
                    sqlite_conn.Close();
                    s4 = "Customer Number can't be change ! Turn back to " + s1;
                    MessageBox.Show(s4, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                else
                {
                    sqlite_conn.Close();

                    sqlite_conn1 = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");

                    sqlite_conn1.Open();


                    sqlite_cmd1 = sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "UPDATE Billing set FirstName='" + textBox20.Text + "',LastName='" + textBox21.Text + "',Address='" + textBox22.Text + "',ContactNumber='" + textBox23.Text + "',age=" + textBox24.Text + ",Email='" + textBox25.Text + "',Payment=" + textBox26.Text + ",PaymentMade='" + dateTimePicker1.Value.ToShortDateString () + "'where CustomerNo=" + s1 + " ";
                    sqlite_cmd1.ExecuteNonQuery();

                    MessageBox.Show("Update Successfully", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                    textBox19.Clear ();
                    textBox20.Clear ();
                    textBox21.Clear ();
                    textBox22.Clear ();
                    textBox23.Clear ();
                    textBox24.Clear ();
                    textBox25.Clear ();
                    textBox26.Clear ();
                    textBox27.Clear ();
                    sqlite_conn1.Close();

                    display();
                }


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Customer Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Billing where CustomerNo =" + textBox9.Text + " ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                s1 = textBox9.Text;

                if (sqlite_datareader.Read())
                {
                    textBox8.Text = sqlite_datareader.GetString(1);
                    textBox7.Text = sqlite_datareader.GetString(2);
                    textBox6.Text = sqlite_datareader.GetString(3);
                    textBox5.Text = sqlite_datareader.GetString(4);
                    textBox4.Text = sqlite_datareader.GetString(5);
                    textBox3.Text = sqlite_datareader.GetString(6);
                    textBox2.Text = sqlite_datareader.GetString(7);
                    textBox1.Text = sqlite_datareader.GetString(8);
                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Please fetch the data", "FETCH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "Delete FROM Billing where CustomerNo=" + textBox9.Text;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                MessageBox.Show("Delete Successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                textBox9.Clear();
                textBox8.Clear();
                textBox7.Clear();
                textBox6.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Clear();

                display();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox18.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Customer Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Billing where CustomerNo =" + textBox18.Text + " ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                s1 = textBox18.Text;

                if (sqlite_datareader.Read())
                {
                    textBox17.Text = sqlite_datareader.GetString(1);
                    textBox16.Text = sqlite_datareader.GetString(2);
                    textBox15.Text = sqlite_datareader.GetString(3);
                    textBox14.Text = sqlite_datareader.GetString(4);
                    textBox13.Text = sqlite_datareader.GetString(5);
                    textBox12.Text = sqlite_datareader.GetString(6);
                    textBox11.Text = sqlite_datareader.GetString(7);
                    textBox10.Text = sqlite_datareader.GetString(8);
                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            NailArt1 N1 = new NailArt1();
            N1.ShowDialog();

            Billing B1 = new Billing();
            B1.ShowDialog();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            Cutting1 C1 = new Cutting1();
            C1.ShowDialog();


            Billing B1 = new Billing();
            B1.ShowDialog();



        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Close();

            Package1 P1 = new Package1();
            P1.ShowDialog();


            Billing B1 = new Billing();
            B1.ShowDialog();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
