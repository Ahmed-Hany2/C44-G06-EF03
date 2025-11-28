using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{

    [Table("Stud_Course")]
    public class Stud_Course
    {
        [Column("stud_ID")]
        public int stud_ID { get; set; }

        [Column("Course_ID")]
        public int Course_ID { get; set; }

        [Column("Grade", TypeName = "decimal(5,2)")]
        public decimal? Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
