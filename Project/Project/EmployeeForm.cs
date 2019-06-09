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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public void display()
        {
            
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_dataread;

            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select count (*) + 1 from Employee";
            sqlite_dataread = sqlite_cmd.ExecuteReader();

            if (sqlite_dataread.Read())
            {
                textBox1.Text = sqlite_dataread.GetString(0);
                sqlite_conn.Close(); 
            }


            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;

            sqlite_conn1 = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn1.Open();

            sqlite_cmd1 = sqlite_conn1.CreateCommand();

            sqlite_cmd1.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "select * from Employee NATURAL JOIN Derive_Employee ORDER BY Employee.EmployeeNumber";

            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd1);

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlite_conn1.Close();


        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            display();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue; 

            if ((string.IsNullOrWhiteSpace(textBox1.Text)) || (string.IsNullOrWhiteSpace(textBox2.Text)) || (string.IsNullOrWhiteSpace(textBox3.Text)) || (string.IsNullOrWhiteSpace(textBox4.Text)) || (string.IsNullOrWhiteSpace(textBox5.Text)) || (string.IsNullOrWhiteSpace(textBox6.Text)) || (string.IsNullOrWhiteSpace(textBox7.Text)) || (string.IsNullOrWhiteSpace(textBox8.Text)) || (string.IsNullOrWhiteSpace(textBox9.Text))) 
            {
                 MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

            
            else if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("EmployeeNumber is Number Only Field","Invalid Entry",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
             
            else 
            {
                SQLiteConnection sqlite_conn;
                SQLiteConnection sqlite_conn1;
                SQLiteConnection sqlite_conn2; 

                SQLiteCommand sqlite_cmd;
                SQLiteCommand sqlite_cmd1;
                SQLiteCommand sqlite_cmd2;
                SQLiteDataReader sqlite_datareader; 

                sqlite_conn2= new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
                sqlite_conn2.Open();

                sqlite_cmd2 = sqlite_conn2.CreateCommand();

                sqlite_cmd2.CommandText = "select * from Employee where EmployeeNumber=" + textBox1.Text + "";
                sqlite_datareader = sqlite_cmd2.ExecuteReader();

                if (!sqlite_datareader.Read())
                {
                    sqlite_conn2.Close();

                    sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
                    sqlite_conn.Open(); 

                    sqlite_cmd = sqlite_conn.CreateCommand(); 

                    sqlite_cmd.CommandText = "INSERT INTO EMPLOYEE (FirstName,LastName,Address,ContactNumber,email,JobTitle) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();


                    sqlite_conn1 = new SQLiteConnection("Data Source=Derive_Employee.db;Version=3;Compress=True;");
                    sqlite_conn1.Open();

                    sqlite_cmd1 = sqlite_conn1.CreateCommand();
                    sqlite_cmd1.CommandText = "INSERT INTO Derive_Employee (EmployeeNumber,Attendance,Payment) values (" + Convert.ToInt16(textBox1.Text) + ",'" + textBox8.Text + "','" + textBox9.Text + "')";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    MessageBox.Show("Save Successfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();

                    display();

                }

                else
                {
                    MessageBox.Show("Employee Number already exist ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sqlite_conn2.Close();
                }
            }
    }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

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

                    textBox19.Clear();
                    textBox20.Clear();
                    textBox21.Clear();
                    textBox22.Clear();
                    textBox23.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    textBox26.Clear();
                    textBox27.Clear();
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

                string s3=Convert.ToString (textBox19.Text);
                string s4; 

                if (s3!=s1)
                {
                    sqlite_conn.Close();
                    s4 = "Employee Number can't be change ! Turn back to " + s1; 
                    MessageBox.Show(s4, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                else
                {
                    sqlite_conn.Close(); 

                    sqlite_conn1= new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");

                    sqlite_conn1.Open();


                    sqlite_cmd1= sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
                    sqlite_cmd1.ExecuteNonQuery(); 

                    sqlite_cmd1.CommandText = "UPDATE Employee set FirstName='" + textBox20.Text + "',LastName='" + textBox21.Text + "',Address='" + textBox22.Text + "',ContactNumber='" + textBox23.Text + "',Email='" + textBox24.Text + "',JobTitle='" + textBox25.Text + "' where EmployeeNumber=" + s1 + " ";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "UPDATE Derive_Employee set Attendance='" + textBox26.Text + "',Payment='" + textBox27.Text + "' where EmployeeNumber=" + s1 + " ";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox19.Clear();
                    textBox20.Clear();
                    textBox21.Clear();
                    textBox22.Clear();
                    textBox23.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    textBox26.Clear();
                    textBox27.Clear();

                    display();
                }

                
             }

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox28.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Employee Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                s1 = textBox28.Text;

                sqlite_cmd.CommandText = "select * from Employee NATURAL JOIN Derive_Employee where Employee.EmployeeNumber=" + textBox28.Text + "";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    textBox29.Text = sqlite_datareader.GetString(1);
                    textBox30.Text = sqlite_datareader.GetString(2);
                    textBox31.Text = sqlite_datareader.GetString(3);
                    textBox32.Text = sqlite_datareader.GetString(4);
                    textBox33.Text = sqlite_datareader.GetString(5);
                    textBox34.Text = sqlite_datareader.GetString(6);
                    textBox35.Text = sqlite_datareader.GetString(7);
                    textBox36.Text = sqlite_datareader.GetString(8);
                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox28.Clear();
                    textBox29.Clear();
                    textBox30.Clear();
                    textBox31.Clear();
                    textBox32.Clear();
                    textBox33.Clear();
                    textBox34.Clear();
                    textBox35.Clear();
                    textBox36.Clear();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox29.Text))
            {
                MessageBox.Show("Please kindly fetch data", "FETCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                //SQLiteDataReader sqlite_datareader;


                sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Employee.db' as D1";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Delete FROM Employee where EmployeeNumber=" + textBox28.Text;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Delete FROM Derive_Employee where EmployeeNumber=" + textBox28.Text;
                sqlite_cmd.ExecuteNonQuery();


                sqlite_conn.Close();

                MessageBox.Show("Delete Successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox28.Clear();
                textBox29.Clear();
                textBox30.Clear();
                textBox31.Clear();
                textBox32.Clear();
                textBox33.Clear();
                textBox34.Clear();
                textBox35.Clear();
                textBox36.Clear();

                display();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
