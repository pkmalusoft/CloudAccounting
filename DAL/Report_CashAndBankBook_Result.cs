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
    
    public partial class Report_CashAndBankBook_Result
    {
        public int AcJournalID { get; set; }
        public Nullable<System.DateTime> TransDate { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherType { get; set; }
        public Nullable<int> AcJournalDetailID { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> DrAmount { get; set; }
        public Nullable<decimal> CrAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public string AcHead { get; set; }
        public string Details { get; set; }
    }
}
