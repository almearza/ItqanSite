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
    
    public partial class IMAGE_header
    {
        public int ID_Image { get; set; }
        public string Titile { get; set; }
        public string descreption { get; set; }
        public string IMG_Path { get; set; }
        public Nullable<int> Lang { get; set; }
    
        public virtual Lang1 Lang1 { get; set; }
    }
}
