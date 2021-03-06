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
    
    public partial class CurrencyMaster
    {
        public CurrencyMaster()
        {
            this.BranchMasters = new HashSet<BranchMaster>();
            this.AcCompanies = new HashSet<AcCompany>();
        }
    
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public Nullable<short> NoOfDecimals { get; set; }
        public string MonetaryUnit { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<bool> StatusBaseCurrency { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
    
        public virtual ICollection<BranchMaster> BranchMasters { get; set; }
        public virtual ICollection<AcCompany> AcCompanies { get; set; }
    }
}
