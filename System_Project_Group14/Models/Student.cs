using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace System_Project_Group14.Models
{
    public enum GradSemester { Fall, Summer, Spring}
    public enum Major { Accounting, BusinessHonors, Finance, InternationalBusiness, Management, MIS, Marketing, SCM, STM }
    public enum PositionType { Internship, FullTime}


    public class Student : AppUser
    {
        List <int> years = Enumerable.Range(DateTime.Now.Year, 10).ToList();

        [Key]
        public Int32 StudentID { get; set; }

        [Required(ErrorMessage = "Please select a major.")]
        [EnumDataType(typeof(Major))]
        public Major Major { get; set; }

        [Required(ErrorMessage = "Please select a graduating semester.")]
        [EnumDataType(typeof(GradSemester))]
        public GradSemester GradSemester {get; set;}

        // Need drop down for graduation year
        //[Required(ErrorMessage= "Please select a graduating year.")]
        

        [Required(ErrorMessage = "Please select a position type.")]
        [EnumDataType(typeof(PositionType))]
        public PositionType StudentPosition {get; set;}

        [Required(ErrorMessage = "Please enter a GPA."),Range(0.00,4.00,ErrorMessage="GPA must be between 0.00 and 4.00")]
        [Display(Name = "GPA")]
        public decimal GPA {get; set;}

        //Navigation properties
        public virtual List<AppliedStudents> StudentsApplied { get; set; }

            
            
        }




        

}
