using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TidrAppProject.Models
{
    public class WorkShift
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Start of shift")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End of shift")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Total time")]
        public double TotalTime { get; set; }

        public double OB1 { get; set; }

        public double OB2 { get; set; }

        [Display(Name = "First sick day")]
        public bool FirstSickDay { get; set; }

        [Display(Name = "Sick day time")]
        public double SickDayTime { get; set; }

        public double VAB { get; set; }

        public virtual Employee Employee { get; set; }



    }
}