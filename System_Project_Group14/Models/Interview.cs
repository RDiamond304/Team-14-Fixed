using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Project_Group14.Models
{
    public class Interview
    {
        [Key]
        public Int32 InterviewID { get; set; }

        //Something for Interview Times
        //Something for Interview Rooms
        //Something for Interviewer/Recruiter(?)

        //Navigation Properties
        public virtual Position PositionName { get; set; }
        public virtual Company CompanyName { get; set; }
        public virtual Student StudentID {get; set;}

    }
}