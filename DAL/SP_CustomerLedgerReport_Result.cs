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
    
    public partial class SP_CustomerLedgerReport_Result
    {
        public int ID { get; set; }
        public System.DateTime DATE { get; set; }
        public string DOCUMENTNO { get; set; }
        public string PARTICULARS { get; set; }
        public decimal DEBIT { get; set; }
        public decimal CREDIT { get; set; }
        public decimal BALANCE { get; set; }
    }
}
