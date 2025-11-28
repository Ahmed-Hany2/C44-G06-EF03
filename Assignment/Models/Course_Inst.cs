using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment.Models
{

    [Table("Course_Inst")]
    public class Course_Inst
    {
        [Column("inst_ID")]
        public int inst_ID { get; set; }

        [Column("Course_ID")]
        public int Course_ID { get; set; }

        [MaxLength(200)]
        [Column("evaluate")]
        public string evaluate { get; set; }

        // Navigation Properties
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
