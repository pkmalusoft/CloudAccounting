//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirFrightDetail
    {
        public int AirFrightDetailsID { get; set; }
        public Nullable<int> AirFrightID { get; set; }
        public string Weight { get; set; }
        public Nullable<decimal> Fright { get; set; }
        public Nullable<decimal> FuelSurcharge { get; set; }
        public Nullable<decimal> CarrierSecurity { get; set; }
        public Nullable<decimal> AirlineHandling { get; set; }
    }
}
