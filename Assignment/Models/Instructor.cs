using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    [Table("Instructor")]
    public class Instructor
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string Name { get; set; }

        [Column("Salary", TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [MaxLength(200)]
        [Column("Adress")]
        public string Address { get; set; }

        [Column("HourRate", TypeName = "decimal(18,2)")]
        public decimal HourRate { get; set; }

        [Column("Bouns", TypeName = "decimal(18,2)")]
        public decimal Bonus { get; set; }

        [Column("Dept_ID")]
        public int? Dept_ID { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public ICollection<Department> ManagedDepartments { get; set; } = new List<Department>();
        public ICollection<Course_Inst> Course_Insts { get; set; } = new List<Course_Inst>();
    }
}
