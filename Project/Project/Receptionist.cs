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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            EmployeeForm1 E1 = new EmployeeForm1();
            E1.ShowDialog();

            Receptionist R1 = new Receptionist();
            R1.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide (); 
            this.Close ();

            Billing B1 = new Billing();
            B1.ShowDialog();

            Receptionist R1 = new Receptionist();
            R1.ShowDialog(); 
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            ReceptionistProfile R1 = new ReceptionistProfile();
            R1.ShowDialog();

            this.Close();

            if (R1.i == 1)
            {
                LoginForm L1 = new LoginForm();
                L1.ShowDialog();
            }

            else
            {
                Receptionist R11 = new Receptionist();
                R11.ShowDialog();
            } 


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            LoginForm L1 = new LoginForm();
            L1.ShowDialog(); 
            



        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide ();
            this.Close ();

            Feedback F1 = new Feedback();
            F1.ShowDialog();

            Receptionist R1 = new Receptionist();
            R1.ShowDialog();
        }
    }
}
