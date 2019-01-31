using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TidrAppProject.Models
{
    public class Employee
    {
        
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Personal number")]
        [RegularExpression(@"^\d\d\d\d\d\d\d\d-\d\d\d\d$", ErrorMessage = "Personal number must be correctly formatted (XXXXXXXX-XXXX)")]
        public string PersonalNumber { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Hired")]
        [DataType(DataType.Date)]
        public DateTime HiredDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string ProfilePic { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Salary per hour")]
        [DataType(DataType.Currency)]
        public double HourlySalary { get; set; }

        [Display(Name = "Salary per Month")]
        [DataType(DataType.Currency)]
        public double MonthlySalary { get; set; }

        public string UserID { get; set; }
        public virtual ICollection<WorkShift> WorkShifts { get; set; }

    }
}