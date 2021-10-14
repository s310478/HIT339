using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public enum GenderType
    {
        Male,
        Female,
        NonBinary
    }

    public class Student
    {

        // Primary key
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(200)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string StudentFirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(400)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string StudentLastName { get; set; }

        public string StudentFullName
        {
            get
            {
                return StudentFirstName + " " + StudentLastName;
            }
        }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime StudentDOB { get; set; }

        [Display(Name = "Student Age")]
        public int StudentAge
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - StudentDOB.Year;
                if (StudentDOB > now.AddYears(-age)) age--;
                return age;
            }
        }
            

        [Display(Name = "Student Gender")]
        public GenderType StudentGender { get; set; }

        [Display(Name = "Parent/Guardian Name")]
        [StringLength(200)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string StudentsParent { get; set; }

        [Display(Name = "Payment Contact Email Address")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }

        [Display(Name = "Payment Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]*$")]
        public string StudentPhone { get; set; }

    }
}