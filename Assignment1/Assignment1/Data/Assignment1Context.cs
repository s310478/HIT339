using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class Assignment1Context : DbContext
    {
        public Assignment1Context (DbContextOptions<Assignment1Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment1.Models.Student> Student { get; set; }

        public DbSet<Assignment1.Models.Tutor> Tutor { get; set; }

        public DbSet<Assignment1.Models.Instrument> Instrument { get; set; }

        public DbSet<Assignment1.Models.DurationCost> DurationCost { get; set; }

        public DbSet<Assignment1.Models.Lesson> Lesson { get; set; }

        public DbSet<Assignment1.Models.Letter> Letter { get; set; }
    }
}
