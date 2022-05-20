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
    public partial class formitem : Form
    {
        public formitem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();
            List<itemViewModel> list = ent.items.Select(d => new itemViewModel { item_code = d.item_code, name= d.name}).ToList();
            dataGridView1.DataSource = list;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Please enter all the required data..! ");
            }
            else
            {
                EFDBEntities ent = new EFDBEntities();
                item dmn = new item();


                dmn.item_code =int.Parse( textBox1.Text);

                dmn.name = textBox2.Text;
                


                textBox1.Text = textBox2.Text = String.Empty;


                ent.items.Add(dmn);
                ent.SaveChanges();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            int code =int.Parse( textBox1.Text);

            var item = (from d in ent.items
                       where d.item_code == code
                       select d).First();

            if (item != null)
            {
                item.name = textBox2.Text;

              

                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text  = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int code = int.Parse(textBox1.Text);
            EFDBEntities ent = new EFDBEntities();
            var item = from d in ent.items
                      where d.item_code == code
                      select d;
            if (item != null)
            {
                int count = 0;
                foreach (var d in item)
                {
                    ent.items.Remove(d);
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
