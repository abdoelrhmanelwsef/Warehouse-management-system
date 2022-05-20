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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();
            List<WharehouseViewModel> list =ent.Wharehouses.Select(z => new WharehouseViewModel { address= z.address , Manager_Name = z.Manager_Name , Warehouse_Name = z.Warehouse_Name}).ToList();

            dataGridView1.DataSource= list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please enter all the required data..! ");
            }
            else
            {
                Wharehouse wr = new Wharehouse();
                wr.address = textBox2.Text;
                wr.Manager_Name = textBox3.Text;
                wr.Warehouse_Name = textBox1.Text;
                textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
                EFDBEntities ent = new EFDBEntities();

                ent.Wharehouses.Add(wr);
                ent.SaveChanges();
                MessageBox.Show("Data Addede");
                textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();
            string name = textBox1.Text;
            var war = (from d in ent.Wharehouses
                       where d.Warehouse_Name == name
                       select d).First();

            if (war != null)
            {
                war.address = textBox2.Text;
                war.Manager_Name = textBox3.Text;
                ent.SaveChanges();
                MessageBox.Show("Data is changed");
            }
            textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            EFDBEntities ent = new EFDBEntities();
            var wr = from d in ent.Wharehouses
                     where d.Warehouse_Name == name
                     select d;
            if (wr != null)
            {
                int count = 0;
                foreach (var w in wr)
                {
                    ent.Wharehouses.Remove(w);
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
