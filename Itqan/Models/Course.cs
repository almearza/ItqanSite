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
    
    public partial class Course
    {
        public int ID_course { get; set; }
        public string Name_Course { get; set; }
        public string Descreption_Course { get; set; }
        public string IMG_course { get; set; }
        public Nullable<System.DateTime> dateStart { get; set; }
        public Nullable<int> id_define { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    
        public virtual Define_Itqan Define_Itqan { get; set; }
    }
}