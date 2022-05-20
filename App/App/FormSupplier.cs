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
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EFDBEntities ent = new EFDBEntities();
            List<SupplierViewModel> list = ent.Suppliers.Select(z => new SupplierViewModel {Supplier_Email = z.Supplier_Email , Name = z.Name , Phone = z.Phone , fax = z.fax , website= z.website , telephone = z.telephone }).ToList();
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
                Supplier sp = new Supplier();


                sp.Supplier_Email = textBox1.Text;

                sp.Name = textBox2.Text;
                sp.Phone = textBox3.Text;
                sp.fax = textBox4.Text;
                sp.website = textBox5.Text;
                sp.telephone = textBox6.Text;


                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;


                ent.Suppliers.Add(sp);
                ent.SaveChanges();
                MessageBox.Show("Data Added");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            string email = textBox1.Text;

            var supp = (from d in ent.Suppliers
                        where d.Supplier_Email == email
                        select d).First();

            if (supp != null)
            {
                supp.Name = textBox2.Text;

                supp.Phone = textBox3.Text;
                supp.fax = textBox4.Text;
                supp.website = textBox5.Text;
                supp.telephone = textBox6.Text;
                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            EFDBEntities ent = new EFDBEntities();
            var supp = from d in ent.Suppliers
                       where d.Supplier_Email == email
                       select d;
            if (supp != null)
            {
                int count = 0;
                foreach (var s in supp)
                {
                    ent.Suppliers.Remove(s);
                    count++;
                }
                ent.SaveChanges();
                MessageBox.Show(count + "  WareHouse Deleted");
            }
            else
            {
                MessageBox.Show("WareHouse Dosen't Exist");
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
