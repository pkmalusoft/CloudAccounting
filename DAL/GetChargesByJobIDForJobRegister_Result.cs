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
    
    public partial class GetChargesByJobIDForJobRegister_Result
    {
        public Nullable<int> JobID { get; set; }
        public int InvoiceID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> SalesHome { get; set; }
        public Nullable<decimal> ProvisionHome { get; set; }
        public Nullable<int> AcHeadID { get; set; }
        public string AcHead { get; set; }
        public string SupplierName { get; set; }
    }
}
