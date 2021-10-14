using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{

    public class Instrument
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Student Instrument")]
        public string StudentInstrument { get; set; }


    }
}
