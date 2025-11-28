using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Duration")]
        public int Duration { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string Description { get; set; }

        [Column("Top_ID")]
        public int? Top_ID { get; set; }

        // Navigation Properties
        public Topic Topic { get; set; }
        public ICollection<Stud_Course> Stud_Courses { get; set; } = new List<Stud_Course>();
        public ICollection<Course_Inst> Course_Insts { get; set; } = new List<Course_Inst>();
    }
}
