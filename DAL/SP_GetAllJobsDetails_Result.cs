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
    
    public partial class SP_GetAllJobsDetails_Result
    {
        public int JobID { get; set; }
        public Nullable<int> InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> JobDate { get; set; }
        public string JobDescription { get; set; }
        public string JobCode { get; set; }
        public string CostUpdatedOrNot { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public string Customer { get; set; }
    }
}
