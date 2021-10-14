using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string TutorFirstName { get; set; }

        [Display(Name = "Last Name"), Required]
        public string TutorLastName { get; set; }

        public string TutorFullName
        {
            get
            {
                return TutorFirstName + " " + TutorLastName;
            }
        }

        [Display(Name = "Contact Number"), Phone]
        public string PaymentPhone { get; set; }

    }
}
