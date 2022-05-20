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
    public partial class transfareItems : Form
    {
        public transfareItems()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFDBEntities ent = new EFDBEntities();


            string email = textBox1.Text;
            string oldWharehouse = textBox2.Text;

            int itemCode = int.Parse(textBox3.Text);
            string newWharehouse = textBox4.Text;

            var supp1 = (from d in ent.Supplies
                        where d.supplier_Email == email
                        select d).First();

            var supp2 = (from d in ent.Supplies
                         where d.Wharehouse_Name == oldWharehouse
                         select d).First();

            var supp3 = (from d in ent.Supplies
                         where d.item_code == itemCode
                         select d).First();

            var supp4 = (from d in ent.Supplies
                         where d.Wharehouse_Name == newWharehouse
                         select d).First();

            if (supp1 != null && supp2 != null && supp3 !=null && supp4 != null)
            {
               supp4.quantity = supp1.quantity;
                supp4.supply_code=supp1.supply_code;
                supp4.data = supp1.data;
                supp4.Expiredays = supp1.Expiredays;
                supp4.productionDate = supp1.productionDate;

                ent.SaveChanges();

            }
            MessageBox.Show("Data is changed");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = String.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }
    }
    }

