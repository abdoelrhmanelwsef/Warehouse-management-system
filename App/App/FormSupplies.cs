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
    public partial class FormSupplies : Form
    {
        public FormSupplies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();
            List<SuppliesViewModel> list = ent.Supplies.Select(x => new SuppliesViewModel {supplier_Email = x.supplier_Email, Wharehouse_Name = x.Wharehouse_Name , item_code = x.item_code , supply_code = x.supply_code , data = x.data , quantity = x.quantity , Expiredays = x.Expiredays , productionDate = x.productionDate }).ToList();
            dataGridView1.DataSource= list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Please enter all the required data..! ");
            }
            else
            {
                EFDBEntities ent = new EFDBEntities();
                Supply sup = new Supply();


                sup.supplier_Email = textBox1.Text;

                sup.Wharehouse_Name = textBox2.Text;
                sup.item_code = int.Parse(textBox3.Text);
                sup.supply_code = int.Parse(textBox4.Text);
                sup.data =textBox5.Text;
                sup.quantity = int.Parse(textBox6.Text);
                sup.Expiredays =DateTime.Parse(textBox7.Text);
                sup.productionDate = DateTime.Parse(textBox8.Text);



                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;


                ent.Supplies.Add(sup);
                ent.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            string email = textBox1.Text;

            var supp = (from d in ent.Supplies
                        where d.supplier_Email == email
                        select d).First();

            if (supp != null)
            {
                supp.supply_code = int.Parse(textBox4.Text);

                supp.data = textBox5.Text;
                supp.quantity = int.Parse(textBox6.Text);
                supp.Expiredays = DateTime.Parse(textBox7.Text);

                supp.productionDate = DateTime.Parse(textBox8.Text);
                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            EFDBEntities ent = new EFDBEntities();
            var supp = from d in ent.Supplies
                       where d.supplier_Email == email
                       select d;
            if (supp != null)
            {
                int count = 0;
                foreach (var s in supp)
                {
                    ent.Supplies.Remove(s);
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
