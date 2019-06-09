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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();

            Package P1 = new Package();
            P1.ShowDialog();


            Services s1 = new Services();
            s1.ShowDialog(); 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            Make_Up m1 = new Make_Up();
            m1.ShowDialog(); 

            Services s1=new Services (); 
            s1.ShowDialog (); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close(); 

            Cutting c1 = new Cutting();
            c1.ShowDialog();

            Services s1 = new Services();
            s1.ShowDialog(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide ();
            this.Close();

            Nail_Art n1 = new Nail_Art();
            n1.ShowDialog();

            Services s1 = new Services();
            s1.ShowDialog(); 

        }
    }
}
