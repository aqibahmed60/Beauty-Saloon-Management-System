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
    public partial class Billing1 : Form
    {
        public Billing1()
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
        private void Billing1_Load(object sender, EventArgs e)
        {
            display();
        }

        private string s1; 

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

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
