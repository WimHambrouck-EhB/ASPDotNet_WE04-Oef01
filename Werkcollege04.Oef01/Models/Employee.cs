using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Werkcollege04.Oef01.Models
{
    [Table("Emp")]
    public class Employee
    {
        [Key]
        public int Empno { get; set; }
        [Column("Ename")]
        public string Name { get; set; }
        public Job Job { get; set; }
        [ForeignKey(nameof(Manager))]
        public int? Mgr { get; set; }
        public virtual Employee Manager { get; set; }

        [DataType(DataType.Date)]
        public DateTime Hiredate { get; set; }
        [Column("Sal")]
        public double Salary { get; set; }
        [Column("Comm")]
        public double Commission { get; set; }

        [Display(Name = nameof(Department))]
        [ForeignKey(nameof(Department))]
        public virtual int Deptno { get; set; }
        public virtual Department Department { get; set; }

    }
}
