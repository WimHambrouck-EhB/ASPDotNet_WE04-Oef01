using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Werkcollege04.Oef01.Models
{
    [Table("Dept")]
    public class Department
    {
        [Key]
        public int Deptno { get; set; }
        [Column("Dname")]
        public string Name { get; set; }
        [Column("Loc")]
        public string Location { get; set; }
    }
}
