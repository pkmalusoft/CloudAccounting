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
    
    public partial class ReportCustomerReceipt_Result
    {
        public string Date { get; set; }
        public string ReceivedFrom { get; set; }
        public string DocumentNo { get; set; }
        public decimal Amount { get; set; }
        public string Account { get; set; }
        public decimal ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string CustomerBank { get; set; }
        public string Remarks { get; set; }
        public string DetailDocNo { get; set; }
        public string DocDate { get; set; }
        public decimal DocAmount { get; set; }
        public int AdjustmentAmount { get; set; }
        public decimal SettledAmount { get; set; }
    }
}