﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Project_Group14.Models
{
    public class Company
    {
        [Key]
        public Int32 CompanyID { get; set; }
        //Comment testing
        [Required(ErrorMessage = "Company name is required.")]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        [Required(ErrorMessage = "Company description is required.")]
        [Display(Name = "Company Description")]
        public String CompanyDescription { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public String CompanyEmail { get; set; }

        //Navigation properties
        [Display(Name = "Positions Available")]
        public virtual List<Position> PositionsAvailable { get; set; }

        [Display(Name = "Industries")]
        public virtual List<Industry> CompanyIndustry { get; set; }






    }
}