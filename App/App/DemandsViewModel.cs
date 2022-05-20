using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class DemandsViewModel
    {
        public string Customer_Email { get; set; }
        public string Wharehouse_Name { get; set; }
        public int item_code { get; set; }
        public Nullable<int> demand_Code { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> quantity { get; set; }

    }
}
