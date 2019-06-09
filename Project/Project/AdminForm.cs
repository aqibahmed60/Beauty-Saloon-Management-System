using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Finisar.SQLite;
using System.IO;

namespace Project
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        public void display_Data ()
        {
            //SQLiteConnection sqlite_conn;
            //SQLiteCommand sqlite_cmd;
            //SQLiteDataReader sqlite_datareader;

            Administator A2 = new Administator(); 

            using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;") )
            { 

                sqlite_conn.Open();
               
                using (SQLiteCommand sqlite_cmd= new SQLiteCommand ("SELECT Username FROM Login where Username='"+A2.GetUserName()+"' and Password='"+A2.GetPasswords()+"'",sqlite_conn )) 
                {
                    sqlite_cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    sqlite_conn.Close();
                } 
             }
            

            //sqlite_cmd.CommandText = "SELECT * FROM Login where Username='" + A2.GetUserName () + "'and Password='" + A2.GetPasswords () + "'";
            //sqlite_cmd.CommandText = "SELECT * FROM Login where Username='"+A2.GetUserName()+"' and Password='"+A2.GetPasswords()+"'";
           // sqlite_cmd.ExecuteNonQuery();

            //DataTable dt = new DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

        }

        
        private void AdminForm_Load(object sender, EventArgs e)
        {
            display_Data();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administator A1 = new Administator(); 

            SQLiteConnection sqlite_conn;
            SQLiteConnection sqlite_conn1; 

            SQLiteCommand sqlite_cmd;
            SQLiteCommand sqlite_cmd1; 

            SQLiteDataReader sqlite_datareader;
            //SQLiteDataReader sqlite_datareader1; 

            sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "select * from Login where Password ='" + textBox3.Text + "'";
            sqlite_datareader = sqlite_cmd.ExecuteReader(); 

            if (sqlite_datareader.Read())
            {
                string a1 = sqlite_datareader.GetString(0);
                sqlite_conn.Close();
                
                sqlite_conn1 = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
                sqlite_conn1.Open();

                sqlite_cmd1 = sqlite_conn1.CreateCommand(); 

             
                sqlite_cmd1.CommandText = "Update Login SET Password='" + textBox4.Text + "' where Password='" + textBox3.Text + "'";
                sqlite_cmd1.ExecuteNonQuery();

                A1.SetData(a1, textBox3.Text);

                sqlite_conn1.Close();

               

                MessageBox.Show("Password Update");

                textBox3.Clear();
                textBox4.Clear();

            }

            else
            {
                sqlite_conn.Close(); 
                MessageBox.Show("Can't Update Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox3.Clear();
                textBox4.Clear();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Administator A1 = new Administator();


            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill the missing field !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            
            else 
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                SQLiteDataReader sqlite_dataread;
                
                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1;
                SQLiteDataReader sqlite_dataread1;

                SQLiteConnection sqlite_conn2;
                SQLiteCommand sqlite_cmd2;
                

                sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;"); 
                sqlite_conn.Open ();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "Select * from Login where Username='" + A1.GetUserName() +"' and Password='" + textBox5.Text + "'";
                sqlite_dataread = sqlite_cmd.ExecuteReader();

                if (sqlite_dataread.Read())
                {
                    sqlite_conn.Close();
                    sqlite_conn1 = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
                    sqlite_conn1.Open();

                    sqlite_cmd1 = sqlite_conn1.CreateCommand();

                    sqlite_cmd1.CommandText = "select * from Login where Username='" + textBox2.Text + "'"; //UserName Verification 
                    sqlite_dataread1 = sqlite_cmd1.ExecuteReader();

                    if (!sqlite_dataread1.Read())
                    {
                        sqlite_conn1.Close();

                        sqlite_conn2 = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
                        sqlite_conn2.Open();

                        sqlite_cmd2 = sqlite_conn2.CreateCommand();

                        sqlite_cmd2.CommandText = "Update Login set Username='" + textBox2.Text + "' where Username='" + A1.GetUserName() + "' and Password='" + textBox5.Text + "'";
                        sqlite_cmd2.ExecuteNonQuery();

                        sqlite_conn2.Close();

                        A1.SetData(textBox2.Text, textBox5.Text);
                        display_Data();

                        MessageBox.Show("Username Update","UPDATE",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        textBox2.Clear();
                        textBox5.Clear();
                    }

                    else
                    {
                        sqlite_conn1.Close();
                        MessageBox.Show("Username can not be Update", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox2.Clear();
                        textBox5.Clear();
                    }

                    /*sqlite_cmd1.CommandText = "Update Login set Username='" + textBox2.Text + "' where Username='" + A1.GetUserName() + "' and Password='" + textBox5.Text + "'";
                    sqlite_cmd1.ExecuteNonQuery();
                    sqlite_conn1.Close();
                    */ 

                    

                     

                }

                else 
                { 
                    sqlite_conn.Close (); 
                    MessageBox.Show ("Invalid Password ! Username can not be update","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    textBox2.Clear();
                    textBox5.Clear();
                }

                
               
                
            }

             

            


        }

        public int i=0; 

        private void button4_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show ("Do you want to delete your account ? After pressing yes you will be logout from account and your account will be remove!", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Administator A1 = new Administator();

                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                SQLiteDataReader sqlite_dataread; 

                SQLiteConnection sqlite_conn1;
                SQLiteCommand sqlite_cmd1; 

                sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "Select * from Login where Username='" + textBox6.Text + "' and Password='" + textBox1.Text + "'";
                sqlite_dataread = sqlite_cmd.ExecuteReader();

                if (sqlite_dataread.Read())
                {
                    sqlite_conn.Close();
                    sqlite_conn1 = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;"); 
                    sqlite_conn1.Open();

                    sqlite_cmd1 = sqlite_conn1.CreateCommand(); 

                    sqlite_cmd1.CommandText = "Delete from Login where Username='" + A1.GetUserName() + "' and Password='" + A1.GetPasswords() + "'";
                    sqlite_cmd1.ExecuteNonQuery();

                    sqlite_conn1.Close();

                    i = 1;

                    this.Hide();
                    this.Close();
                }

                else
                {
                    i = 0;
                    sqlite_conn.Close();
                    MessageBox.Show("Username and Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 


                


                

                

                

            } 



            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

         

        
        }

    
        

        
    
}
