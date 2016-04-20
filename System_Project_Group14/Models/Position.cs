using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_Project_Group14.Models
{
    public enum PType { Internship, FullTime }
    public class Position
    {
        public Int32 PositionID { get; set; }

        [Required(ErrorMessage = "Position title is required.")]
        [Display(Name = "Position Title")]
        public String PositionTitle { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public String PositionDescription { get; set; }

        [Required]
        [EnumDataType(typeof(PType))]
        public PType PositionTypes { get; set; }

        [Required]
        [EnumDataType(typeof(Major))]
        public Major ApplicableMajor { get; set; }

        [Required(ErrorMessage = "Deadline is required.")]
        [Display(Name = "Deadline")]
        public DateTime PositionDeadline { get; set; }

        //Navigation Properties
        public virtual Company CompanyName { get; set; }
        //public virtual List<Interview> InterviewTimes { get; set; }
        public virtual List<AppliedStudents> StudentsApplied { get; set; }


    }
}
