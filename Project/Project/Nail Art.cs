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
    public partial class Nail_Art : Form
    {
        public Nail_Art()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void display()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select * from NailArt";

            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

            da.Fill(dt);
            dataGridView2.DataSource = dt;

            sqlite_conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double parsedValue1;
            double parsedValue2;

            if ((string.IsNullOrWhiteSpace(textBox1.Text)) || (string.IsNullOrWhiteSpace(textBox2.Text)) || (string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (!(double.TryParse(textBox2.Text, out parsedValue1)) || !(double.TryParse(textBox3.Text, out parsedValue2)))
            {
                MessageBox.Show("It is Number Only Field", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {
                SQLiteConnection sqlite_conn;
                //SQLiteConnection sqlite_conn1;
                SQLiteConnection sqlite_conn2;

                SQLiteCommand sqlite_cmd;
                //SQLiteCommand sqlite_cmd1;
                SQLiteCommand sqlite_cmd2;
                SQLiteDataReader sqlite_datareader;

                sqlite_conn2 = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
                sqlite_conn2.Open();

                sqlite_cmd2 = sqlite_conn2.CreateCommand();

                sqlite_cmd2.CommandText = "select * from NailArt where Category='" + textBox1.Text + "'";
                sqlite_datareader = sqlite_cmd2.ExecuteReader();

                if (!sqlite_datareader.Read())
                {
                    sqlite_conn2.Close();

                    sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "INSERT INTO NailArt (Category,Hands,Feet) values ('" + textBox1.Text + "'," + textBox2.Text + "," + textBox3.Text + ")";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();


                    MessageBox.Show("Save Successfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                    display();

                }

                else
                {
                    MessageBox.Show("Category already exist ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sqlite_conn2.Close();
                }
            }
        }

        private void Nail_Art_Load(object sender, EventArgs e)
        {
            display();
        }

        private string s1;

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Category", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from NailArt where lower (Category)='" + textBox6.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();


                if (sqlite_datareader.Read())
                {
                    s1 = textBox6.Text;
                    textBox5.Text = sqlite_datareader.GetString(1);
                    textBox4.Text = sqlite_datareader.GetString(2);

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
            float parsedValue;
            float parsedValue1;

            if ((string.IsNullOrWhiteSpace(textBox6.Text)) || (string.IsNullOrWhiteSpace(textBox5.Text)) || (string.IsNullOrWhiteSpace(textBox4.Text)))
            {

                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (!float.TryParse(textBox5.Text, out parsedValue) || !float.TryParse(textBox4.Text, out parsedValue1))
            {

                MessageBox.Show("it is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                //SQLiteDataReader sqlite_datareader;

                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;

                sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");

                sqlite_conn.Open();


                sqlite_cmd = sqlite_conn.CreateCommand();

                string s3 = textBox6.Text;
                string s4;

                if (s3 != s1)
                {
                    sqlite_conn.Close();
                    s4 = "Category can't be change ! Turn back to " + s1;
                    MessageBox.Show(s4, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                else
                {
                    sqlite_conn.Close();

                    sqlite_conn1 = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");

                    sqlite_conn1.Open();
                    sqlite_cmd1 = sqlite_conn1.CreateCommand();
                    sqlite_cmd1.CommandText = "UPDATE NailArt set Hands=" + textBox5.Text + ",Feet=" + textBox4.Text + " where lower (Category)='" + s1.ToLower() + "'";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    MessageBox.Show("Update successfully", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox6.Clear();
                    textBox5.Clear();
                    textBox4.Clear(); 

                    display();
                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Category", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from NailArt where lower (Category)='" + textBox9.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();


                if (sqlite_datareader.Read())
                {
                    s1 = textBox9.Text;
                    textBox8.Text = sqlite_datareader.GetString(1);
                    textBox7.Text = sqlite_datareader.GetString(2);

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
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            //SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            if (String.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                sqlite_cmd.CommandText = "DELETE from NailArt where lower (Category)='" + textBox9.Text.ToLower() + "'";
                sqlite_cmd.ExecuteNonQuery();
                display();

                MessageBox.Show("Delete successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox9.Clear();
                textBox8.Clear();
                textBox7.Clear();

                sqlite_conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();


            if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Category", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from NailArt where lower (Category)='" + textBox12.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();


                if (sqlite_datareader.Read())
                {
                    s1 = textBox12.Text;
                    textBox11.Text = sqlite_datareader.GetString(1);
                    textBox10.Text = sqlite_datareader.GetString(2);

                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
