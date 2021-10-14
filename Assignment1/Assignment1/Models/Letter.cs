using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Letter
    {
        public int Id { get; set; }

        public string StudentName { get; set; }
        public string Begin_comment { get; set; }
        public string Term { get; set; }
        public string Term_Start { get; set; }
        public string Payment_Final { get; set; }
        public string Reference_Number { get; set; }
        public string Student_FirstName { get; set; }
        public string Student_LastName { get; set; }
        public string Amount { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }
        public string Bank { get; set; }
        public string Account_Name { get; set; }
        public string BSB { get; set; }
        public string Account_Number { get; set; }
        public string Signature { get; set; }
        public Boolean Paid { get; set; }


    }
}
