using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTO.FlowerDTO
{
    public class FlowerByIdDTO
    {
        
        [StringLength(50)]
        public string? Name { get; set; }
        public int? NbPetal { get; set; }

        [ForeignKey("Field")]
        public int? FieldId { get; set; }
    }
}
