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
    
    public partial class AnalysisHead
    {
        public int AnalysisHeadID { get; set; }
        public string AnalysisCode { get; set; }
        public string AnalysisHead1 { get; set; }
        public Nullable<int> AnalysisGroupID { get; set; }
        public Nullable<int> BranchID { get; set; }
    
        public virtual AnalysisGroup AnalysisGroup { get; set; }
        public virtual AcCompany AcCompany { get; set; }
    }
}