//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public string supplier_Email { get; set; }
        public string Wharehouse_Name { get; set; }
        public int item_code { get; set; }
        public Nullable<int> supply_code { get; set; }
        public string data { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> Expiredays { get; set; }
        public Nullable<System.DateTime> productionDate { get; set; }
    
        public virtual item item { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Wharehouse Wharehouse { get; set; }
    }
}