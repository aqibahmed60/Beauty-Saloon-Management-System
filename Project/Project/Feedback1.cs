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
    public partial class Feedback1 : Form
    {
        public Feedback1()
        {
            InitializeComponent();
        }

        public void display()
        {
            if (comboBox2.Items.Count != 0)
            {
                comboBox2.Items.Clear();
            }

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select count (CustomerNo) from Billing";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            string s1;

            if (sqlite_datareader.Read())
            {
                s1 = sqlite_datareader.GetString(0);

                int n1 = Convert.ToInt32(s1);

                for (int i = 1; i <= n1; i++)
                {
                    comboBox2.Items.Add(i);   
                }
            }

            sqlite_conn.Close();
        }  


        private void Feedback1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s1 = "Customer" + comboBox2.Text + ".txt";

            if (!File.Exists(s1))
            {
                MessageBox.Show("File does not exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox2.Clear();
            }

            else
            {
                TextReader reader = new StreamReader(s1);
                richTextBox2.Text = reader.ReadToEnd();

                reader.Close();

            } 
        }
    }
}
