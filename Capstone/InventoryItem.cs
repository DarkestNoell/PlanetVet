//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventoryItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string StockOnHand { get; set; }
        public Nullable<double> PricePerUnit { get; set; }
    }
}