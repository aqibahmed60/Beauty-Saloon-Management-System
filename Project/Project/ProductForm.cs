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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = comboBox1.Text;

            string s2 = "Make Up ";
            string s3 = "Hair Care ";
            string s4 = "Beauty Tools ";
            string s5 = "Skin Care";

            if (string.Equals(s1, s2))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Foundation");
                comboBox2.Items.Add("Lips");
                comboBox2.Items.Add("Eyes");
                comboBox2.Items.Add("Nails");

            }

            if (string.Equals(s1, s3))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Shampoo");
                comboBox2.Items.Add("Hair Treatment");
                comboBox2.Items.Add("Hair Coloring");
                comboBox2.Items.Add("Hair Contioner");
                comboBox2.Items.Add("Hair Styling");
            }

            if (string.Equals(s1, s4))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Curling Iron And Wands");
                comboBox2.Items.Add("Hair Dryer");
                comboBox2.Items.Add("Hair Removal");

            }

            if (string.Equals(s1, s5))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Face Scrubs");
                comboBox2.Items.Add("Facial Cleanser");
                comboBox2.Items.Add("Foot Care");
                comboBox2.Items.Add("Hand Care");
            }
        }

        private void display()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "select Product.*,Derive_Table.*,Price*Quantity as Total_Cost from Product NATURAL JOIN Derive_TABLE ORDER BY Product.Category";

            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlite_conn.Close();

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            display();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float parsedValue1;
            int parsedValue2;

            string s1 = comboBox1.Text;

            //string s2 = "Make Up ";
            

            if ((string.IsNullOrWhiteSpace(comboBox1.Text)) || (string.IsNullOrWhiteSpace(comboBox2.Text)) || (string.IsNullOrWhiteSpace(textBox1.Text)) || (string.IsNullOrWhiteSpace(textBox2.Text)) || (string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

            else if (!(float.TryParse(textBox2.Text,out parsedValue1)) || (!int.TryParse(textBox3.Text, out parsedValue2)))
            {

                MessageBox.Show("Price (PKR) and Quantity is Number Only Field", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                sqlite_conn2 = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
                sqlite_conn2.Open();

                sqlite_cmd2 = sqlite_conn2.CreateCommand();

                sqlite_cmd2.CommandText = "select * from Product where lower (ProductName)='" + textBox1.Text.ToLower () + "'";
                sqlite_datareader = sqlite_cmd2.ExecuteReader();

                if (!sqlite_datareader.Read())
                {
                    sqlite_conn2.Close();

                    sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                    string s5 = textBox1.Text;

                    sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + s5 + "')";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();


                    sqlite_conn1 = new SQLiteConnection("Data Source=Derive_Product.db;Version=3;Compress=True;");
                    sqlite_conn1.Open();


                    sqlite_cmd1 = sqlite_conn1.CreateCommand();
                    sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE (ProductName,Price,Quantity) values ('" + s5 + "'," + textBox2.Text + "," + textBox3.Text + ")";
                    sqlite_cmd1.ExecuteNonQuery();


                    sqlite_conn1.Close();

                    MessageBox.Show("Product Save Successfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    
                    display();

                }

                else
                {
                    MessageBox.Show("Product Name already exist ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sqlite_conn2.Close();

                    
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Product Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select Product.*,Derive_TABLE.*,Quantity*Price from Product NATURAL JOIN Derive_TABLE where lower (Product.ProductName)='" + textBox4.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    textBox7.Text = sqlite_datareader.GetString(0);
                    textBox8.Text = sqlite_datareader.GetString(1);
                    textBox5.Text = sqlite_datareader.GetString(3);
                    textBox6.Text = sqlite_datareader.GetString(4);
                    textBox9.Text = sqlite_datareader.GetString(5);

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

            SQLiteDataReader sqlite_datareader;


            sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Product Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select Product.*,Derive_TABLE.*,Quantity*Price from Product NATURAL JOIN Derive_TABLE where lower (Product.ProductName)='" + textBox10.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    textBox11.Text = sqlite_datareader.GetString(0);
                    textBox12.Text = sqlite_datareader.GetString(1);
                    textBox13.Text = sqlite_datareader.GetString(3);
                    textBox14.Text = sqlite_datareader.GetString(4);
                    textBox15.Text = sqlite_datareader.GetString(5);

                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            //SQLiteDataReader sqlite_datareader;

            if (string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox11.Text) || string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox13.Text) || string.IsNullOrWhiteSpace(textBox14.Text) || string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Please fetch data", "FETCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Delete FROM Product where lower (ProductName)='" + textBox10.Text.ToLower() + "'";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "Delete FROM Derive_TABLE where lower (ProductName)='" + textBox10.Text.ToLower() + "'";
                sqlite_cmd.ExecuteNonQuery();


                sqlite_conn.Close();

                MessageBox.Show("Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();

                display();
            }
        }

        private string s1;

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;

            s1 = textBox16.Text;

            sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
            sqlite_cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(textBox16.Text))
            {
                sqlite_conn.Close();
                MessageBox.Show("Please enter the Product Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                sqlite_cmd.CommandText = "select Product.*,Derive_TABLE.*,Quantity*Price from Product NATURAL JOIN Derive_TABLE where lower (Product.ProductName)='" + textBox16.Text.ToLower() + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    comboBox3.Text = sqlite_datareader.GetString(0);
                    comboBox4.Text = sqlite_datareader.GetString(1);
                    textBox19.Text = sqlite_datareader.GetString(3);
                    textBox20.Text = sqlite_datareader.GetString(4);

                    sqlite_conn.Close();
                }

                else
                {
                    sqlite_conn.Close();
                    MessageBox.Show("Search Not Found !", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double parsedValue1;
            int parsedValue2; 

            if ((string.IsNullOrWhiteSpace(textBox16.Text)) || (string.IsNullOrWhiteSpace(comboBox3.Text)) || (string.IsNullOrWhiteSpace (comboBox4.Text)) || (string.IsNullOrWhiteSpace(textBox19.Text)) || (string.IsNullOrWhiteSpace(textBox20.Text)) )
            {
                
                MessageBox.Show("Please fill the missing field !", "Field Not Fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if ((!double.TryParse(textBox19.Text, out parsedValue1)) || (!int.TryParse(textBox20.Text, out parsedValue2)))
            {
                
                MessageBox.Show("Price (PKR) and Quantity is Number Only Field !", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                //SQLiteDataReader sqlite_datareader;

                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;

                sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");

                sqlite_conn.Open();


                sqlite_cmd = sqlite_conn.CreateCommand();

                string s3=Convert.ToString (textBox16.Text);
                string s4; 

                if (s3.ToLower()!=s1.ToLower())
                {
                    sqlite_conn.Close();
                    s4 = "Product name can't be change ! Turn back to " + s1; 
                    MessageBox.Show(s4, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                else
                {
                    sqlite_conn.Close(); 

                    sqlite_conn1= new SQLiteConnection("Data Source=Product.db;Version=3;Compress=True;");

                    sqlite_conn1.Open();


                    sqlite_cmd1= sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "ATTACH DATABASE 'Derive_Product.db' as D1";
                    sqlite_cmd1.ExecuteNonQuery(); 

                    sqlite_cmd1.CommandText = "UPDATE Product set Category ='" + comboBox3.Text + "',Type='" + comboBox4.Text + "' where lower (ProductName)='" + s1.ToLower() + "'";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_cmd1.CommandText = "UPDATE Derive_TABLE set Price=" + textBox19.Text + ",Quantity=" + textBox20.Text + "where lower (ProductName)='" + s1.ToLower() + "'";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();
                    
                    MessageBox.Show ("Update successfully","Update",MessageBoxButtons.OK,MessageBoxIcon.Information); 

                    textBox16.Clear ();
                    textBox19.Clear ();
                    textBox20.Clear ();

                    display();
                }

        }
      }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = comboBox3.Text;
            string s6 = comboBox3.Text; 

            string s2 = "Make Up ";
            string s3 = "Hair Care ";
            string s4 = "Beauty Tools ";
            string s5 = "Skin Care";

            if (string.Equals(s1, s2))
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Foundation");
                comboBox4.Items.Add("Lips");
                comboBox4.Items.Add("Eyes");
                comboBox4.Items.Add("Nails");

            }

            if (string.Equals(s1, s3))
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Shampoo");
                comboBox4.Items.Add("Hair Treatment");
                comboBox4.Items.Add("Hair Coloring");
                comboBox4.Items.Add("Hair Contioner");
                comboBox4.Items.Add("Hair Styling");
            }

            if (string.Equals(s1, s4))
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Curling Iron And Wands");
                comboBox4.Items.Add("Hair Dryer");
                comboBox4.Items.Add("Hair Removal");

            }

            if (string.Equals(s6,s5))
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Face Scrubs");
                comboBox4.Items.Add("Facial Cleanser");
                comboBox4.Items.Add("Foot Care");
                comboBox4.Items.Add("Hand Care");
            }
        }
    }

}


