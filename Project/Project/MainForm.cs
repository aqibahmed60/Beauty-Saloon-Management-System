using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            LoginForm L1 = new LoginForm();
            L1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            this.Close();
            AdminForm AF = new AdminForm();
            AF.ShowDialog();

            this.Close();

            if (AF.i == 1)
            {
                LoginForm L1 = new LoginForm();
                L1.ShowDialog();
            }

            else
            {
                MainForm m1 = new MainForm();
                m1.ShowDialog();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close(); 

            EmployeeForm E1 = new EmployeeForm();
            E1.ShowDialog();

            MainForm m1 = new MainForm();
            m1.ShowDialog(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close(); 

            ProductForm p1 = new ProductForm();
            p1.ShowDialog();

            MainForm m1 = new MainForm();
            m1.ShowDialog();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            Services s1 = new Services();
            s1.ShowDialog();

            MainForm m1 = new MainForm();
            m1.ShowDialog(); 

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            Billing1 B1 = new Billing1();
            B1.ShowDialog();

            MainForm m1 = new MainForm();
            m1.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide (); 
            this.Close ();

            Feedback1 F1 = new Feedback1();
            F1.ShowDialog();

            MainForm m1 = new MainForm();
            m1.ShowDialog();
        } 


    }
}
