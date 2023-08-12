//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoccerDiv.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class News
    {
        public int News_ID { get; set; }

        [Required(ErrorMessage = "Enter customer  name!!")]
        [Display(Name = "Customer Name")]
        public int Customer_ID { get; set; }

        [Required(ErrorMessage = "Enter news title!!")]
        [Display(Name = "News Title")]
        public string News_Title { get; set; }

        [Required(ErrorMessage = "Enter news date!!")]
        [Display(Name = "News Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> News_Date { get; set; }

        [Required(ErrorMessage = "Enter news date!!")]
        [Display(Name = "News Date")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> NewsTime { get; set; }

        [Display(Name = "News Caption")]
        public string News_Image { get; set; }

        [Required(ErrorMessage = "Enter news description!!")]
        [Display(Name = "Tournaments Name")]
        public string News_Dexcription { get; set; }

        public HttpPostedFileBase NewsImageFile { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
