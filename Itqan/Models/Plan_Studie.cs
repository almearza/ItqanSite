//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Itqan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan_Studie
    {
        public int ID_Plan { get; set; }
        public string Plan_Studie1 { get; set; }
        public Nullable<int> ID_define { get; set; }
        public Nullable<int> Lang { get; set; }
    
        public virtual Define_Itqan Define_Itqan { get; set; }
        public virtual Lang1 Lang1 { get; set; }
    }
}
