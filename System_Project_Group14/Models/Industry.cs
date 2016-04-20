using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Project_Group14.Models
{
    public class Industry
    {
        [Key]
        public Int32 IndustryID { get; set; }

        [Required(ErrorMessage = "Industry name is required.")]
        [Display(Name = "Industry Name")]
        public String IndustryName { get; set; }

        //Navigation Property
        [Display(Name = "Companies")]
        public virtual List<Company> IndustryCompany { get; set; }

        [Display(Name = "Positions Available")]
        public virtual List<Position> IndustryPosition { get; set; }

    }
}