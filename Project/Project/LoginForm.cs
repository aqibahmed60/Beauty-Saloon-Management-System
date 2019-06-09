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
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void Product_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Product.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE Product (Category varchar2 (100),Type varchar2 (100),ProductName varchar2 (100) NOT NULL Primary Key)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Foundation','Fluid Foundation 21')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Foundation','Loreal Visible Lift CC Cream Foundation')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Foundation','Fit Me Liquid Foundation-115 ivory')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Foundation','Super Stay Foundation')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Foundation','Matt Mousse LB Foundation Mousse')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Lips','Clazona matte Lip Gloss')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Lips','Glitter Lipstick G-75')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Lips','Glitter Lipstick G-69')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Lips','WOW Peel Off Lipgloss')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Lips','Shimmer Liquid Lipstick')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Eyes','Loreal Paris Kajal')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Product (Category,Type,ProductName) VALUES ('Make Up','Eyes','Maxi Black Liner')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

            SQLiteConnection sqlite_conn1;
            SQLiteCommand sqlite_cmd1;


            sqlite_conn1 = new SQLiteConnection("Data Source=Derive_Product.db;Version=3;New=True;Compress=True;");
            sqlite_conn1.Open();

            sqlite_cmd1 = sqlite_conn1.CreateCommand();

            sqlite_cmd1.CommandText = "CREATE TABLE Derive_TABLE (ProductName varchar2 (100) NOT NULL, PRICE NUMBER (100),QUANTITY INTEGER,CONSTRAINT fk_Product_Name FOREIGN KEY (ProductName) REFERENCES Product (ProductName))";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Fluid Foundation 21', 2395, 5)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Loreal Visible Lift CC Cream Foundation',399,3)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Fit Me Liquid Foundation-115 ivory',490,2)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Super Stay Foundation',2500,10)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Matt Mousse LB Foundation Mousse',1995,15)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Clazona matte Lip Gloss',310,100)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Glitter Lipstick G-75',245,50)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Glitter Lipstick G-69',95,100)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('WOW Peel Off Lipgloss',311,100)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Shimmer Liquid Lipstick',311,55)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Loreal Paris Kajal',160,15)";
            sqlite_cmd1.ExecuteNonQuery();

            sqlite_cmd1.CommandText = "INSERT INTO Derive_TABLE VALUES ('Maxi Black Liner',1299,50)";
            sqlite_cmd1.ExecuteNonQuery();


            sqlite_conn1.Close();



        }

        public void Package_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Count.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE COUNT_DB (total_count NUMBER)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO COUNT_DB (total_count) values (1)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void Employee_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Employee.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "Create Table Employee (EmployeeNumber INTEGER Primary Key NOT NULL,FirstName varchar2 (100),LastName varchar2 (100),Address varchar2 (100),ContactNumber varchar2 (15),email varchar2 (100),JobTitle varchar2 (100))";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Employee (FirstName,LastName,Address,ContactNumber,email,JobTitle) VALUES ('Zainab','Ahmed','B448 BLOCK 13 FB-Area Karachi','0313-3765952','zainab.ahmed@hotmail.com','MakeUp Specialist')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Employee (FirstName,LastName,Address,ContactNumber,email,JobTitle) VALUES ('Iqra','Ali','B144 BLOCK 14 FB-Area Karachi','0331-3775658','iqra.ali@yahoo.com','MakeUp Specialist')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Employee (FirstName,LastName,Address,ContactNumber,email,JobTitle) VALUES  ('Ayesha','Imtiaz','D35 BLOCK 7 Clifton Karachi','0321-3886568','ayesha.imtiaz@gmail.com','Hair Specialist')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Employee (FirstName,LastName,Address,ContactNumber,email,JobTitle) VALUES  ('Alina','Ahmed','9/11 street 28 Defence Phase 4 Karachi','0313-3996462','alina_ahmed@hotmail.com','Dermatologist')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

            sqlite_conn = new SQLiteConnection("Data Source=Derive_Employee.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "Create TABLE Derive_Employee (EmployeeNumber INTEGER NOT NULL,Attendance varchar2 (4),Payment varchar2 (100),CONSTRAINT fk_empno FOREIGN KEY (EmployeeNumber) REFERENCES Employee (EmployeeNumber) )";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Derive_Employee values (1,'92%','50,000 PKR')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Derive_Employee values (2,'88%','47,000 PKR')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Derive_Employee values (3,'97%','75,000 PKR')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Insert INTO Derive_Employee values (4,'98%','100,000 PKR')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

        }

        public void Total_Cost_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Cost.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE Total_Cost (PackageNumber NUMBER NOT NULL Primary Key,cost FLOAT)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

        }

        public void Make_Up_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=MakeUp.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE Make_Up (Level NUMBER NOT NULL UNIQUE,Party FLOAT,Bridal FLOAT)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void Cutting_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=Cutting.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE Cutting (Level NUMBER NOT NULL UNIQUE,Cost FLOAT)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void Nail_Art_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=NailArt.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE NailArt (Category varchar2 (100) NOT NULL UNIQUE,Hands FLOAT,Feet FLOAT)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO NailArt (Category,Hands,Feet) values ('Repair',400,400)";
            sqlite_cmd.ExecuteNonQuery();


            sqlite_conn.Close();
        }

        public void Billing_DB()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd; 

            sqlite_conn = new SQLiteConnection("Data Source=Billing.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE Billing (CustomerNo INTEGER Primary Key NOT NULL,FirstName varchar2 (100),LastName varchar2 (100),Address varchar2 (100),ContactNumber varchar2 (100),Age integer,Email varchar2 (100),Payment FLOAT,PaymentMade varchar2 (100))";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Billing (FirstName,LastName,Address,ContactNumber,Age,Email,Payment,PaymentMade) values ('Shazia','Ahmed','D/80 Block 7 Clifton Karachi','0332-3687619',18,'shazia.ahmed@gmail.com',1500,'19-JULY 2019')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Billing (FirstName,LastName,Address,ContactNumber,Age,Email,Payment,PaymentMade) values ('Hania','Ahmed','D/50 Block 10 Clifton Karachi','0332-3687619',18,'hania.ahmed@gmail.com',2200.95,'11-JULY-2019')";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close(); 

        } 



        private void button1_Click(object sender, EventArgs e)
        {
            // We use these three SQLite objects:

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            if (!File.Exists("Login.db"))
            {


                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;New=True;Compress=True;");

                // open the connection
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // Let the SQLiteCommand object know our SQL-Query:
                sqlite_cmd.CommandText = "CREATE TABLE Login (Username varchar2 (100), Password varchar2 (100));";


                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();

                // Lets insert something into our new table:
                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('aqibahmed60', 'abcabc');";

                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                // ...and inserting another line:
                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('ossaidahmed', '1234');";

                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                // ...and inserting another line:
                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('HafizHarisAlam', 'otaku');";

                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                // But how do we read something out of our table ?
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM Login where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";

                Administator A1 = new Administator();

                A1.SetData(textBox1.Text, textBox2.Text);

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();


                // The SQLiteDataReader allows us to run through the result lines:
                if (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    sqlite_conn.Close();
                    Employee_DB();
                    Product_DB();
                    Package_DB();
                    Total_Cost_DB();
                    Make_Up_DB();
                    Cutting_DB();
                    Nail_Art_DB();
                    this.Hide();
                    MainForm m1 = new MainForm();
                    m1.ShowDialog();

                    LoginForm L1 = new LoginForm();
                    L1.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Invalid Login", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear(); 
                }

                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }


            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=Login.db;Version=3;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                // But how do we read something out of our table ?
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM Login where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
                Administator A1 = new Administator();

                A1.SetData(textBox1.Text, textBox2.Text);
                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                if (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    this.Hide();
                    sqlite_conn.Close();
                    MainForm m1 = new MainForm();
                    m1.ShowDialog();

                    LoginForm L1 = new LoginForm();
                    L1.ShowDialog();

                }

                else
                {
                    MessageBox.Show("Invalid Login", "Login Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear();
                }

                sqlite_conn.Close();
                // We are ready, now lets cleanup and close our connection


            }
        }  

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            if (!File.Exists ("ReceptionistLogin.db")) 
            {
            

               sqlite_conn = new SQLiteConnection("Data Source=ReceptionistLogin.db;Version=3;New=True;Compress=True;");

               sqlite_conn.Open();

               sqlite_cmd = sqlite_conn.CreateCommand();


               sqlite_cmd.CommandText = "CREATE TABLE Login (Username varchar2 (100) NOT NULL UNIQUE, Password varchar2 (100));";
               sqlite_cmd.ExecuteNonQuery();

            
                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('aqibahmed60', 'abcabc');";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('ossaidahmed', '1234');";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "INSERT INTO Login (Username,Password) VALUES ('HafizHarisAlam', 'otaku');";
                sqlite_cmd.ExecuteNonQuery();

            
                sqlite_cmd.CommandText = "SELECT * FROM Login where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
                sqlite_datareader=sqlite_cmd.ExecuteReader();

                Receptionists R10 = new Receptionists();
                R10.SetData(textBox1.Text, textBox2.Text);

                if (sqlite_datareader.Read()) 
                {
                    sqlite_conn.Close();
                    Billing_DB(); 
                    this.Hide();
                    Receptionist R1 = new Receptionist(); 
                    R1.ShowDialog();

                    LoginForm L1 = new LoginForm();
                    L1.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Invalid Login", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear();
                } 
                
                    sqlite_conn.Close();
            } 


            else 
            {
                sqlite_conn=new SQLiteConnection("Data Source=ReceptionistLogin.db;Version=3;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "SELECT * FROM Login where Username='"+textBox1.Text+"'and Password='" + textBox2.Text+"'";

                Receptionists R10 = new Receptionists();
                R10.SetData(textBox1.Text, textBox2.Text); 


                sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read()) 
                {
                    this.Hide();
                    sqlite_conn.Close();
                    Receptionist R1 = new Receptionist();
                    R1.ShowDialog();

                    LoginForm L1 = new LoginForm();
                    L1.ShowDialog();

                }

                else 
                {
                    MessageBox.Show("Invalid Login","Login Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear();
                }

                
                sqlite_conn.Close();
            

        }
    }
    }
}