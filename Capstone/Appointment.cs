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
    
    public partial class Appointment
    {
        public int Id { get; set; }
        public int DayID { get; set; }
        public System.DateTime Time { get; set; }
        public bool SlotTaken { get; set; }
        public string Client { get; set; }
        public string Patient { get; set; }
        public string Description { get; set; }
    }
}