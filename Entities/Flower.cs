using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Flower
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public int NbPetal { get; set; }

        [ForeignKey("Field")]
        public int? FieldId { get; set; }

        public Field? Field { get; set; }
    }
}
