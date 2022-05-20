using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formitem form = new formitem();
            form.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormSupplies form = new FormSupplies();
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormSupplier form = new FormSupplier();
            form.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormCustomer form = new FormCustomer();
            form.Show();
            this.Hide();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormDemands form = new FormDemands();
            form.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            reports form = new reports();
            form.Show();
            this.Hide();
        }
    }
}
