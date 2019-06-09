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
    public partial class Package : Form
    {
        public Package()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_package()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            sqlite_conn = new SQLiteConnection("Data Source=Count.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select count (total_count) from COUNT_DB";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            string a1;

            if (sqlite_datareader.Read())
            {

                textBox2.Text = sqlite_datareader.GetString(0);
                a1 = sqlite_datareader.GetString(0);
                int n1 = Convert.ToInt32(a1); 

                for (int i = 1; i < n1; i++)
                {
                    comboBox1.Items.Add(Convert.ToString(i));
                    comboBox2.Items.Add(Convert.ToString(i));
                    comboBox3.Items.Add(Convert.ToString(i));
                    comboBox4.Items.Add(Convert.ToString(i));
                }
            }

            sqlite_conn.Close();
        }

        public void display_grid_view()
        {

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

          
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please fill the missing field:", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string s1 = "Package" + comboBox1.Text + ".db";

                sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "ATTACH DATABASE 'Cost.db' as D1";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "select Deals,cost from Package a,Total_Cost b where a.PackageNumber=b.PackageNumber";

                DataTable dt = new DataTable();

                SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlite_conn.Close();
            }
        }


        private void Package_Load(object sender, EventArgs e)
        {
            display_package();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the name you like to insert in package:", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Packages.Items.Add(textBox1.Text);
                textBox1.Focus();
                textBox1.Clear();
            }







        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double parsedValue;

            if (!double.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("Total Cost is Number Only Field", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                string s1 = "Package" + textBox2.Text + ".db";

                int n1 = Convert.ToInt32(textBox2.Text);
                n1 += 1;

                sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;New=True;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "ATTACH DATABASE 'Cost.db' as D1";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Create TABLE Package (PackageNumber NUMBER NOT NULL,Deals varchar2 (100) NOT NULL,CONSTRAINT fk_package_no FOREIGN KEY (PackageNumber) references Total_Cost (PackageNumber) )";
                sqlite_cmd.ExecuteNonQuery();

                int n2 = n1 - 1;

                foreach (var items in Packages.Items)
                {
                    //MessageBox.Show(items.ToString()); 

                    sqlite_cmd.CommandText = "INSERT INTO Package (PackageNumber,Deals) values (" + n2 + ",'" + items.ToString() + "')";
                    sqlite_cmd.ExecuteNonQuery();
                }


                sqlite_conn.Close();


                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;


                sqlite_conn1 = new SQLiteConnection("Data Source=Count.db;Version=3;Compress=True;");
                sqlite_conn1.Open();

                sqlite_cmd1 = sqlite_conn1.CreateCommand();

                sqlite_cmd1.CommandText = "INSERT INTO Count_DB (total_count) VALUES (" + n1 + ")";
                sqlite_cmd1.ExecuteNonQuery();

                sqlite_conn1.Close();


                SQLiteConnection sqlite_conn2;
                SQLiteCommand sqlite_cmd2;

                sqlite_conn2 = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
                sqlite_conn2.Open();

                sqlite_cmd2 = sqlite_conn2.CreateCommand();

                sqlite_cmd2.CommandText = "Insert INTO Total_Cost (PackageNumber,cost) VALUES (" + n2 + "," + textBox3.Text + ")";
                sqlite_cmd2.ExecuteNonQuery();

                sqlite_conn2.Close();

                MessageBox.Show("Package is saved successfully", "Package", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                Packages.Items.Clear();
                textBox3.Clear(); 

                display_package();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display_grid_view();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count != 0)
            {
                listBox1.Items.Clear();
            }

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_dataread;

            string s1 = "Package" + comboBox2.Text + ".db";

            //int n1 = Convert.ToInt32(textBox2.Text);
            //n1 += 1;

            sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select Deals from Package";
            sqlite_dataread = sqlite_cmd.ExecuteReader();


            while (sqlite_dataread.Read())
            {
                listBox1.Items.Add(sqlite_dataread.GetString(0));
            }

            sqlite_conn.Close();

            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_dataread1;

            sqlite_conn1 = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
            sqlite_conn1.Open();


            sqlite_cmd1 = sqlite_conn1.CreateCommand();

            sqlite_cmd1.CommandText = "select * from Total_Cost where PackageNumber=" + comboBox2.Text + "";
            sqlite_dataread1 = sqlite_cmd1.ExecuteReader();

            if (sqlite_dataread1.Read())
            {
                textBox4.Text = sqlite_dataread1.GetString(1);
            }

            sqlite_conn1.Close();


            display_package();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter the name you like to insert in package:", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Please kindly fetch data before update !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

            else
            {
                listBox1.Items.Add(textBox6.Text);
                textBox6.Focus();
                textBox6.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            double parsevalue;

            if (!double.TryParse(textBox4.Text, out parsevalue))
            {
                MessageBox.Show("Total Cost is Number Only Field", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                string s1 = "Package" + comboBox2.Text + ".db";

                //int n1 = Convert.ToInt32(comboBox2.Text);
                //n1 += 1;

                sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;New=True;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "ATTACH DATABASE 'Cost.db' as D1";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Create TABLE Package (PackageNumber NUMBER NOT NULL,Deals varchar2 (100) NOT NULL,CONSTRAINT fk_package_no FOREIGN KEY (PackageNumber) references Total_Cost (PackageNumber) )";
                sqlite_cmd.ExecuteNonQuery();


                int n2 = Convert.ToInt32(comboBox2.Text);
                 

                foreach (var items in listBox1.Items)
                {
                   
                    sqlite_cmd.CommandText = "INSERT INTO Package (PackageNumber,Deals) values (" + n2 + ",'" + items.ToString() + "')";
                    sqlite_cmd.ExecuteNonQuery();
                }

                sqlite_cmd.CommandText = "UPDATE Total_Cost set cost=" + textBox4.Text + " where PackageNumber=" + n2 + "";
                sqlite_cmd.ExecuteNonQuery();


                MessageBox.Show("Package is Update successfully", "Package", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listBox1.Items.Clear();
                textBox4.Clear();

                sqlite_conn.Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                listBox2.Items.Clear();
            }  

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_dataread;

            string s1 = "Package" + comboBox3.Text + ".db";

            //int n1 = Convert.ToInt32(textBox2.Text);
            //n1 += 1;

            sqlite_conn = new SQLiteConnection("Data Source=" + s1 + ";Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select Deals from Package";
            sqlite_dataread = sqlite_cmd.ExecuteReader();


            while (sqlite_dataread.Read())
            {
                listBox2.Items.Add(sqlite_dataread.GetString(0));
            }

            sqlite_conn.Close();

            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_dataread1;

            sqlite_conn1 = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
            sqlite_conn1.Open();

           
            sqlite_cmd1 = sqlite_conn1.CreateCommand();

            sqlite_cmd1.CommandText = "select * from Total_Cost where PackageNumber=" + comboBox3.Text + "";
            sqlite_dataread1 = sqlite_cmd1.ExecuteReader();

            if (sqlite_dataread1.Read())
            {
                textBox5.Text = sqlite_dataread1.GetString(1);
            }

            sqlite_conn1.Close();


            display_package();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
                 
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_dataread;

            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;
            

            string s1 = "Package" + comboBox3.Text + ".db";

            
            if (File.Exists(s1))
            {
                File.Delete(s1);
            }

            sqlite_conn = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select * from Total_Cost ORDER BY PackageNumber desc";
            sqlite_dataread = sqlite_cmd.ExecuteReader();

            string a0;
            string a1; 

            if (sqlite_dataread.Read ()) 
            {
                string s2="Package"+sqlite_dataread.GetString (0)+".db";
                
                a0 = sqlite_dataread.GetString(0);
                a1 = sqlite_dataread.GetString(1); 

                sqlite_conn.Close();

                sqlite_conn1 = new SQLiteConnection("Data Source=Cost.db;Version=3;Compress=True;");
                sqlite_conn1.Open();

                sqlite_cmd1 = sqlite_conn1.CreateCommand();

                if (File.Exists(s2))
                {

                    sqlite_cmd1.CommandText = "UPDATE Total_Cost set Cost=" + a1 + "where PackageNumber=" + comboBox3.Text + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "DELETE from Total_Cost where PackageNumber=" + a0 + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "ATTACH DATABASE 'Count.db' as D1";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "DELETE from Count_DB where total_count=" + a0 + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    sqlite_conn1 = new SQLiteConnection("Data Source=" + s2 + ";Version=3;Compress=True;");
                    sqlite_conn1.Open();

                    sqlite_cmd1 = sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "UPDATE Package set PackageNumber=" + comboBox3.Text + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    File.Move(s2, s1);


                    MessageBox.Show("Package " + a0 + " is now change to Package" + comboBox3.Text);


                }

                else
                {
                    sqlite_cmd1.CommandText = "DELETE from Total_Cost where PackageNumber=" + comboBox3.Text + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "ATTACH DATABASE 'Count.db' as D1";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "DELETE from Count_DB where total_count=" + comboBox3.Text + "";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();
                } 

                
                
            }

            MessageBox.Show("Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

            sqlite_conn.Close();

            listBox2.Items.Clear();
            textBox5.Clear();

            display_package();
            


             
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
