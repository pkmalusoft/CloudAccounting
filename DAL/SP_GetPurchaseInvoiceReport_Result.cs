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
    
    public partial class SP_GetPurchaseInvoiceReport_Result
    {
        public string PurchaseInvoiceNo { get; set; }
        public string PurchaseInvoiceDate { get; set; }
        public string QuotationNumber { get; set; }
        public string Reference { get; set; }
        public string LPOReference { get; set; }
        public string Customer { get; set; }
        public string EmployeeName { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> CreditDays { get; set; }
        public string DueDate { get; set; }
        public string Remarks { get; set; }
        public string DiscountType { get; set; }
        public Nullable<decimal> DiscountValueLC { get; set; }
        public Nullable<decimal> DiscountValueFC { get; set; }
    }
}
