using Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTO.FlowerDTO
{
    public class FlowerDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public int NbPetal { get; set; }

        [ForeignKey("Field")]
        public int? FieldId { get; set; }

    }
}
