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
    public partial class itemPeriodOftimeReport : Form
    {
        public itemPeriodOftimeReport()
        {
            InitializeComponent();
        }

        private void itemPeriodOftimeReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports report = new reports();
            report.Show();
            this.Hide();
        }
    }
}
