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
    
    public partial class SP_GetJOBCostReport_Result
    {
        public string JobNO { get; set; }
        public Nullable<System.DateTime> JobDate { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
        public Nullable<decimal> ProvisionHome { get; set; }
        public Nullable<decimal> SalesHome { get; set; }
        public Nullable<decimal> Profit { get; set; }
        public Nullable<decimal> ProfitRatio { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> InvoiceNo { get; set; }
        public string Customer { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    }
}
