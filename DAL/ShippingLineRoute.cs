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
    
    public partial class ShippingLineRoute
    {
        public int ShippingLineRouteID { get; set; }
        public Nullable<int> RouteID { get; set; }
        public Nullable<int> ShipperID { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<decimal> C20ftAmt { get; set; }
        public Nullable<decimal> C40FtAmt { get; set; }
        public Nullable<decimal> ReeferAmt { get; set; }
    }
}
