using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_Project_Group14.Models
{
    public class InterviewTimes
    {
        public Int32 InterviewTimesID { get; set; }

        public virtual List<InterviewRoomSchedule> InterviewRoomSchedules { get; set; }
    }
}