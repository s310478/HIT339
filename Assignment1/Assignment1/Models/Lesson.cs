using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Student")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }


        [Display(Name = "Instrument")]
        [ForeignKey("Instrument")]
        public int InstrumentId { get; set; }

        [Display(Name = "Tutor")]
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }

        [Display(Name ="Lesson Date")]
        [DataType(DataType.Date)]
        public DateTime LessonDate { get; set; }
        
        [Display(Name ="Lesson Time")]
        [DataType(DataType.Time)]
        public DateTime LessonTime { get; set; }

        [Display(Name ="Duration & Cost")]
        [ForeignKey("DurationCost")]
        public int DurationCostId { get; set; }

        //Letter ID

        public Boolean Paid { get; set; }

        public virtual Student Student { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual DurationCost DurationCost { get; set; }
    }
}
