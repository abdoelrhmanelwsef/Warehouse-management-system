using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class SuppliesViewModel
    {
        public string supplier_Email { get; set; }
        public string Wharehouse_Name { get; set; }
        public int item_code { get; set; }
        public Nullable<int> supply_code { get; set; }
        public string data { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> Expiredays { get; set; }
        public Nullable<System.DateTime> productionDate { get; set; }
    }
}
