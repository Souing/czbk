using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest2
{
    //POCO：
    [Table("T_Persons")]
    public class Person
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }

        public int? Age { get; set; }
    }
}
