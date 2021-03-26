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
        [Editable(false)]
        public int Empno { get; set; }

        [Column("Ename")]
        [Required]
        [DisplayFormat(NullDisplayText = "No manager")]
        public string Name { get; set; }
        public Job Job { get; set; }

        [ForeignKey(nameof(Manager))]
        public int? Mgr { get; set; }

        public Employee Manager { get; set; }

        [DataType(DataType.Date)]
        public DateTime Hiredate { get; set; }

        [Column("Sal")]
        [DataType(DataType.Currency)]
        [Range(1000, double.MaxValue, ErrorMessage = "{0} must be at least {1}")] // cf.: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1#error-messages
        public double Salary { get; set; }

        [Column("Comm")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "{0} cannot be negative")]
        public double Commission { get; set; }

        [Display(Name = nameof(Department))]
        [ForeignKey(nameof(Department))]
        public int Deptno { get; set; }
        public Department Department { get; set; }
    }
}
