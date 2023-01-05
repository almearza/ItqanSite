using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Itqan.Models
{
    [MetadataType(typeof(MetaDataAlnoor))]
    public partial class Alnoor
    {
    }
    public class MetaDataAlnoor
    {
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "الفوائـد")]
        [Required]
        public string AdvantageAlnoor { get; set; }

    }
    [MetadataType(typeof(MetaDataLang1))]
    public partial class Lang1
    {

    }
    public class MetaDataLang1
        {
        [Display(Name ="اللغة")]
        [Required]
        public string Name_lang { get; set; }
        [Display(Name ="الكود")]
        [Required]
        public string Code { get; set; }
    }

    [MetadataType(typeof(MetaDatHeader))]
    public partial class IMAGE_header
    {

    }
    public  class MetaDatHeader
    {
        [Display(Name ="العنوان")]
        [Required]
        public string Titile { get; set; }
        [Display(Name = "المحتوى")]
        [Required]
        public string descreption { get; set; }
        [Display(Name = "الصورة")]
        public string IMG_Path { get; set; }


    }
    [MetadataType(typeof(MetaDataDefine_Itqan))]
    public partial class Define_Itqan
    {

    }
    public class MetaDataDefine_Itqan
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public string Name_Itqan { get; set; }
        [Display(Name = "الرؤية")]
        [Required]
        public string Vision { get; set; }
        [Display(Name = "الرسالة ")]
        [Required]
        public string Message { get; set; }
        [Display(Name = "من نحن")]
        [Required]
        public string Breife { get; set; }
    }

    [MetadataType(typeof(MetaDataGoals))]
    public partial class Goals
    {

    }
    public class MetaDataGoals
    {
        [Display(Name ="الهدف")]
        [Required]
        public string Gaol { get; set; }
        [Display(Name = "منصة اتقان")]
        [Required]
        public Nullable<int> ID_Define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
    }

    [MetadataType(typeof(MetaDataFirstCotent))]
    public partial class FirstContentQuran
    {
       
    }
    public class MetaDataFirstCotent
    {
        [Display(Name ="اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "لمحة القاعدة النورانية")]
        [Required]
        public string FirstContent { get; set; }

    }
    [MetadataType(typeof(MetaDataCondition))]
    public partial class Condition
    {
     
    }
    public class MetaDataCondition
    {
        [Display(Name ="الشرط")]
        [Required]
        public string Descreption_condition { get; set; }
       

       
    }
    [MetadataType(typeof(MetaDataPolice))]
    public partial class Police
    {

    }
    public class MetaDataPolice
    {
        [Display(Name ="الشروط والاحكام")]
        [Required]
        public string Police1 { get; set; }
        public Nullable<int> id_define { get; set; }
        public Nullable<int> Lang { get; set; }

  
    }
    [MetadataType(typeof(MetaDataRequired_IT))]
    public partial class Required_IT
    {

    }
    public class MetaDataRequired_IT
    {
        [Display(Name="منصة اتقان")]
        [Required]
        public Nullable<int> Id_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "المتطلبات التقنية")]
        [Required]
        public string Required_Descreption { get; set; }

    }
    [MetadataType(typeof(MetaDataPlan_Studie))]
    public partial class Plan_Studie
    {

    }
    public class MetaDataPlan_Studie
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> ID_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "الخطط")]
        [Required]
        public string Plan_Studie1 { get; set; }


    }

    [MetadataType(typeof(MetaDataContent_course))]
    public partial class Content_course
    {

    }
    public class MetaDataContent_course
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> ID_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "المنهج التعليمي")]
        [Required]
        public string Content_desc { get; set; }


    }
    [MetadataType(typeof(MetaDataCategore_People))]
    public partial class Categore_People
    {

    }
    public class MetaDataCategore_People
    {
        
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> ID_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "الفئة العمرية")]
        [Required]
        public string Categore_Age { get; set; }
        [Display(Name = "الوصف")]
        [Required]
        public string Descreption_Categore { get; set; }

    }

    [MetadataType(typeof(MetaDataLesson))]
    public partial class Lesson
    {

    }
    public class MetaDataLesson
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> id_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "الجلسة التعليمية")]
        [Required]
        public string Desc_Lesson { get; set; }


    }

    [MetadataType(typeof(MetaDataCard_Feture))]
    public partial class Card_Feture
    {

    }
    public class MetaDataCard_Feture
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> id_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "مزايا اتقان")]
        [Required]
        public string Star_card { get; set; }
       

    }

    [MetadataType(typeof(MetaDataFeture_Itqan))]
    public partial class Feture_Itqan
    {

    }
    public class MetaDataFeture_Itqan
    {
        [Display(Name ="اتقان")]
        [Required]
        public Nullable<int> id_define { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "بماذا تتميز اتقان")]
        [Required]

        public string Descreption_Feture { get; set; }


    }

    [MetadataType(typeof(MetaDataApp))]
    public partial class App
    {

    }
    public class MetaDataApp
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> ID_Itqan { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "اسم التطبيق")]
        [Required]
        public string Name_App { get; set; }
        [Display(Name = "وصف التطبيق")]
        [Required]
        public string Desc_App { get; set; }
      

    }

    [MetadataType(typeof(MetaDataLinks))]
    public partial class Links
    {

    }
    public class MetaDataLinks
    {
        [Display(Name ="منصة اتقان")]
        [Required]
        public Nullable<int> Defien_id { get; set; }
        [Display(Name = "اللغة")]
        [Required]
        public Nullable<int> Lang { get; set; }
        [Display(Name = "الوصف")]
        [Required]
        public string Descreption_Link { get; set; }
        [Display(Name = "الرابط")]
        [Required]
        public string link { get; set; }
       
    }

    [MetadataType(typeof(MetaDataVideo))]
    public partial class Video
    {

    }
    public class MetaDataVideo
    {
        [Display(Name ="منصة اتقان")]
        public Nullable<int> ID_Define { get; set; }
        [Display(Name = "الفديو")]
        [Required]

        public string Video1 { get; set; }



    }


}