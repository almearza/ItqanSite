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
    
    public partial class Goals
    {
        public int ID_Goals { get; set; }
        public string Gaol { get; set; }
        public Nullable<int> ID_Define { get; set; }
        public Nullable<int> Lang { get; set; }
    
        public virtual Lang1 Lang11 { get; set; }
        public virtual Define_Itqan Define_Itqan { get; set; }
    }
}
