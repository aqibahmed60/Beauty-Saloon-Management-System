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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        public void display()
        {
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.Items.Clear ();
            }

            if (comboBox2.Items.Count != 0)
            {
                comboBox2.Items.Clear();
            }

            if (comboBox3.Items.Count != 0)
            {
                comboBox3.Items.Clear();
            }

            if (comboBox4.Items.Count != 0)
            {
                comboBox4.Items.Clear();
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
                    comboBox1.Items.Add(i);
                    comboBox2.Items.Add(i);
                    comboBox3.Items.Add(i);
                    comboBox4.Items.Add(i);

                }
            }

            sqlite_conn.Close();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            display();
        }
        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s1;
            s1 = "Customer" + comboBox1.Text + ".txt";

            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Please enter the text", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (File.Exists(s1))
            {
                MessageBox.Show("File already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Clear();
            }

            else
            {
                TextWriter writer = new StreamWriter(s1);
                writer.Write(richTextBox1.Text);

                writer.Close();

                MessageBox.Show("File Successfully Saved !");

                richTextBox1.Clear();

            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = "Customer" + comboBox3.Text + ".txt";

            if (string.IsNullOrWhiteSpace (richTextBox3.Text)) 
            {
                MessageBox.Show("Please fill the text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

            else if (!File.Exists(s1))
            {
                MessageBox.Show("File does not exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                TextWriter writer = new StreamWriter(s1);
                writer.Write(richTextBox3.Text); 

                writer.Close();

                
                MessageBox.Show("Update have been made","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);

                richTextBox3.Clear();
            } 
  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "Customer" + comboBox4.Text + ".txt";

            if (!File.Exists(s1))
            {
                MessageBox.Show("File does not exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox4.Clear();
            }

            else
            {
                TextReader reader = new StreamReader(s1);
                richTextBox4.Text = reader.ReadToEnd();

                reader.Close();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string s1 = "Customer" + comboBox4.Text + ".txt";

            if (string.IsNullOrWhiteSpace(richTextBox4.Text))
            {
                MessageBox.Show("Please view before you delete !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox4.Clear();
            } 

            else if (File.Exists(s1))
            {
                File.Delete(s1);
                MessageBox.Show("File have been deleted !", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTextBox4.Clear();
            }

            

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "Customer" + comboBox3.Text + ".txt";

            if (!File.Exists(s1))
            {
                MessageBox.Show("File does not exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox3.Clear();
            }

            else
            {
                TextReader reader = new StreamReader(s1);
                richTextBox3.Text = reader.ReadToEnd();

                reader.Close();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
