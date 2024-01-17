using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTO.FlowerDTO
{
    public class FlowerToChangeDTO
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public int? NbPetal { get; set; }

    }
}
