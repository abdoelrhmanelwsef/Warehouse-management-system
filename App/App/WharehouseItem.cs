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
    
    public partial class WharehouseItem
    {
        public string Wharehouse_Name { get; set; }
        public int Item_Code { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual item item { get; set; }
        public virtual Wharehouse Wharehouse { get; set; }
    }
}
