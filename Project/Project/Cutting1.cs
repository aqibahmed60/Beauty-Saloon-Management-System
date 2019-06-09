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
    public partial class Cutting1 : Form
    {
        private string s1;

        public Cutting1()
        {
            InitializeComponent();
        }

        public void display()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select max (CustomerNo)+1 from Billing";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            string s1;

            if (sqlite_datareader.Read())
            {
                s1 = sqlite_datareader.GetString(0);

                if (s1.Length == 0)
                {
                    textBox9.Text = "1";
                }

                else
                {
                    textBox9.Text = sqlite_datareader.GetString(0);
                }
            }

            sqlite_conn.Close();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Cutting.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the level", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Cutting where Level=" + textBox12.Text + "";
                sqlite_datareader = sqlite_cmd.ExecuteReader();


                if (sqlite_datareader.Read())
                {
                    s1 = textBox12.Text;
                    textBox11.Text = sqlite_datareader.GetString(1);

                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void Cutting1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int parsevalue1;
            float parsevalue2;
            double p1;
            double payment;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox11.Text) || string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox13.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!int.TryParse(textBox6.Text, out parsevalue1) || !float.TryParse(textBox1.Text, out parsevalue2))
            {
                MessageBox.Show("It is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            p1 = Convert.ToDouble(textBox11.Text);
            payment = Convert.ToDouble(textBox1.Text);


            if (payment < p1)
            {
                MessageBox.Show("Insufficient Balance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteConnection sqlite_conn2;

                SQLiteCommand sqlite_cmd;
                SQLiteCommand sqlite_cmd2;
                SQLiteDataReader sqlite_datareader;

                sqlite_conn2 = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
                sqlite_conn2.Open();

                sqlite_cmd2 = sqlite_conn2.CreateCommand();

                sqlite_cmd2.CommandText = "select * from Billing where CustomerNo=" + textBox9.Text + "";
                sqlite_datareader = sqlite_cmd2.ExecuteReader();

                if (!sqlite_datareader.Read())
                {
                    sqlite_conn2.Close();

                    sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "INSERT INTO Billing (FirstName,LastName,Address,ContactNumber,Age,Email,Payment,PaymentMade) values ('" + textBox13.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + textBox6.Text + ",'" + textBox7.Text + "'," + textBox1.Text + ",'" + dateTimePicker1.Value.ToShortDateString () + "')";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();

                    MessageBox.Show("Save Successfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                    display();

                }

                else
                {
                    MessageBox.Show("Employee Number already exist ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sqlite_conn2.Close();
                }
            }
        }
    }
}
