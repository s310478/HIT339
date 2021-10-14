using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{

    public class DurationCost
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Lesson Duration (minutes)")]
        public int LessonDuration { get; set; } 

        [Display(Name = "Lesson Cost ($0.00)")]
        public float LessonCost { get; set; }


        public string LessonDurationCost
        {
            get
            {
                return LessonDuration + "min - $" + LessonCost;
            }
        }
    }
}
