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
    
    public partial class ProSupplierAgingDatewise_Result
    {
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> AmtToBeReceived { get; set; }
        public Nullable<decimal> AmtAlreadyReceived { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> DiffDays { get; set; }
    }
}
