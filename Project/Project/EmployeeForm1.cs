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
    public partial class EmployeeForm1 : Form
    {
        public EmployeeForm1()
        {
            InitializeComponent();
        }

        public void display()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "select * from Employee NATURAL JOIN Derive_Employee ORDER BY Employee.EmployeeNumber";

            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlite_conn.Close();
        }

        private void EmployeeForm1_Load(object sender, EventArgs e)
        {
            display();
        }

        private string s1;

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox19.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Employee Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Employee NATURAL JOIN Derive_Employee where Employee.EmployeeNumber=" + textBox19.Text + " ";
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

        private void button4_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if ((string.IsNullOrWhiteSpace(textBox19.Text)) || (string.IsNullOrWhiteSpace(textBox20.Text)) || (string.IsNullOrWhiteSpace(textBox21.Text)) || (string.IsNullOrWhiteSpace(textBox22.Text)) || (string.IsNullOrWhiteSpace(textBox23.Text)) || (string.IsNullOrWhiteSpace(textBox24.Text)) || (string.IsNullOrWhiteSpace(textBox25.Text)) || (string.IsNullOrWhiteSpace(textBox26.Text)) || (string.IsNullOrWhiteSpace(textBox27.Text)))
            {

                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (!int.TryParse(textBox19.Text, out parsedValue))
            {

                MessageBox.Show("EmployeeNumber is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                //SQLiteDataReader sqlite_datareader;

                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;

                sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");

                sqlite_conn.Open();


                sqlite_cmd = sqlite_conn.CreateCommand();

                string s3 = Convert.ToString(textBox19.Text);
                string s4;

                if (s3 != s1)
                {
                    sqlite_conn.Close();
                    s4 = "Employee Number can't be change ! Turn back to " + s1;
                    MessageBox.Show(s4, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                else
                {
                    sqlite_conn.Close();

                    sqlite_conn1 = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");

                    sqlite_conn1.Open();


                    sqlite_cmd1 = sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "UPDATE Employee set FirstName='" + textBox20.Text + "',LastName='" + textBox21.Text + "',Address='" + textBox22.Text + "',ContactNumber='" + textBox23.Text + "',Email='" + textBox24.Text + "',JobTitle='" + textBox25.Text + "' where EmployeeNumber=" + s1 + " ";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "UPDATE Derive_Employee set Attendance='" + textBox26.Text + "',Payment='" + textBox27.Text + "' where EmployeeNumber=" + s1 + " ";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    display();
                }

            }
        } 

      

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Employee Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select * from Employee NATURAL JOIN Derive_Employee where Employee.EmployeeNumber=" + textBox10.Text + "";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    textBox11.Text = sqlite_datareader.GetString(1);
                    textBox12.Text = sqlite_datareader.GetString(2);
                    textBox13.Text = sqlite_datareader.GetString(3);
                    textBox14.Text = sqlite_datareader.GetString(4);
                    textBox15.Text = sqlite_datareader.GetString(5);
                    textBox16.Text = sqlite_datareader.GetString(6);
                    textBox17.Text = sqlite_datareader.GetString(7);
                    textBox18.Text = sqlite_datareader.GetString(8);
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
