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
    
    public partial class CEInvoice
    {
        public int InvoiceID { get; set; }
        public Nullable<int> CustomerEnquiryID { get; set; }
        public Nullable<int> RevenueTypeID { get; set; }
        public Nullable<int> ProvisionCurrencyID { get; set; }
        public Nullable<decimal> ProvisionExchangeRate { get; set; }
        public Nullable<decimal> ProvisionForeign { get; set; }
        public Nullable<decimal> ProvisionHome { get; set; }
        public Nullable<int> SalesCurrencyID { get; set; }
        public Nullable<decimal> SalesExchangeRate { get; set; }
        public Nullable<decimal> SalesForeign { get; set; }
        public Nullable<decimal> SalesHome { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string RevenueCode { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<decimal> ProvisionRate { get; set; }
        public Nullable<decimal> SalesRate { get; set; }
    }
}
