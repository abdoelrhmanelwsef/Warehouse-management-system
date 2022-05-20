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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();

            List<customerViewModel> list = ent.customers.Select(x => new customerViewModel { customer_Email = x.customer_Email , Name = x.Name , phone = x.phone , fax = x.fax , website = x.website , Telephone = x.Telephone}).ToList();
            dataGridView1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please enter all the required data..! ");
            }
            else
            {
                EFDBEntities ent = new EFDBEntities();
                customer cus = new customer();


                cus.customer_Email = textBox1.Text;

                cus.Name = textBox2.Text;
                cus.phone = textBox3.Text;
                cus.fax = textBox4.Text;
                cus.website = textBox5.Text;
                cus.Telephone = textBox6.Text;


                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;


                ent.customers.Add(cus);
                ent.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            string email = textBox1.Text;

            var cust = (from d in ent.customers
                        where d.customer_Email == email
                        select d).First();

            if (cust != null)
            {
                cust.Name = textBox2.Text;

                cust.phone= textBox3.Text;
                cust.fax = textBox4.Text;
                cust.website = textBox5.Text;
                cust.Telephone = textBox6.Text;
                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            EFDBEntities ent = new EFDBEntities();
            var cust = from d in ent.customers
                       where d.customer_Email == email
                       select d;
            if (cust != null)
            {
                int count = 0;
                foreach (var c in cust)
                {
                    ent.customers.Remove(c);
                    count++;
                }
                ent.SaveChanges();
                MessageBox.Show(count + "  Customer Deleted");
            }
            else
            {
                MessageBox.Show("Customer Dosen't Exist");
            }

            textBox1.Text = String.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }
    }
}
