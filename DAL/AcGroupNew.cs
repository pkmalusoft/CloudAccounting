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
    
    public partial class AcGroupNew
    {
        public int AcGroupNewID { get; set; }
        public string AcGroup { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> GroupOrder { get; set; }
    }
}