using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Finisar.SQLite;

namespace Project
{
    public partial class Package1 : Form
    {
        public Package1()
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

        private void display_package()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;

            comboBox4.Items.Clear();

            sqlite_conn = new SQLiteConnection("Data Source=Count.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select count (total_count) from COUNT_DB";

            sqlite_datareader = sqlite_cmd.ExecuteReader();


            if (sqlite_datareader.Read())
            {

                for (int i = 1; i < (Convert.ToInt32(sqlite_datareader.GetString(0))); i++)
                {
                    comboBox4.Items.Add(Convert.ToString(i));
                }
            }

            sqlite_conn.Close();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                listBox3.Items.Clear();
            }

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_dataread;

            string s1 = "Package" + comboBox4.Text + ".db";

            //int n1 = Convert.ToInt32(textBox2.Text);
            //n1 += 1;

            sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select Deals from Package";
            sqlite_dataread = sqlite_cmd.ExecuteReader();


            while (sqlite_dataread.Read())
            {
                listBox3.Items.Add(sqlite_dataread.GetString(0));
            }

            sqlite_conn.Close();

            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_dataread1;

            sqlite_conn1 = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
            sqlite_conn1.Open();


            sqlite_cmd1 = sqlite_conn1.CreateCommand();

            sqlite_cmd1.CommandText = "select * from Total_Cost where PackageNumber=" + comboBox4.Text + "";
            sqlite_dataread1 = sqlite_cmd1.ExecuteReader();

            if (sqlite_dataread1.Read())
            {
                textBox7.Text = sqlite_dataread1.GetString(1);
            }

            sqlite_conn1.Close();

            display_package();
        }


        private void Package1_Load(object sender, EventArgs e)
        {
            display_package();
            display();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int parsevalue1;
            float parsevalue2;
            double p1;
            double payment;

            if (string.IsNullOrWhiteSpace(textBox13.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!int.TryParse(textBox6.Text, out parsevalue1) || !float.TryParse(textBox2.Text, out parsevalue2))
            {
                MessageBox.Show("It is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            p1 = Convert.ToDouble(textBox7.Text);
            payment = Convert.ToDouble(textBox2.Text);


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

                    sqlite_cmd.CommandText = "INSERT INTO Billing (FirstName,LastName,Address,ContactNumber,Age,Email,Payment,PaymentMade) values ('" + textBox13.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + textBox6.Text + ",'" + textBox1.Text + "'," + textBox2.Text + ",'" + dateTimePicker1.Value.ToShortDateString () + "')";
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
