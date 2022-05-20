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
    public partial class FormDemands : Form
    {
        public FormDemands()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();
            List<DemandsViewModel> list = ent.Demands.Select(d => new DemandsViewModel{ Customer_Email = d.Customer_Email , Wharehouse_Name = d.Wharehouse_Name , item_code = d.item_code , demand_Code = d.demand_Code , Date = d.Date , quantity = d.quantity}).ToList();
            dataGridView1.DataSource= list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text =="" || textBox3.Text =="" || textBox4.Text=="" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please enter all the required data..! ");
            }
            else
            {
                EFDBEntities ent = new EFDBEntities();
                Demand dmn = new Demand();


                dmn.Customer_Email = textBox1.Text;

                dmn.Wharehouse_Name = textBox2.Text;
                dmn.item_code = int.Parse(textBox3.Text);
                dmn.demand_Code = int.Parse(textBox4.Text);
                dmn.Date = DateTime.Parse(textBox5.Text);
                dmn.quantity = int.Parse(textBox6.Text);


                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;


                ent.Demands.Add(dmn);
                ent.SaveChanges();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            string email = textBox1.Text;

            var dmn = (from d in ent.Demands
                       where d.Customer_Email == email
                       select d).First();

            if (dmn != null)
            {
                dmn.demand_Code = int.Parse(textBox4.Text);

                dmn.Date = DateTime.Parse(textBox5.Text);
                dmn.quantity = int.Parse(textBox6.Text);

                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            EFDBEntities ent = new EFDBEntities();
            var dmn = from d in ent.Demands
                      where d.Customer_Email == email
                      select d;
            if (dmn != null)
            {
                int count = 0;
                foreach (var d in dmn)
                {
                    ent.Demands.Remove(d);
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
