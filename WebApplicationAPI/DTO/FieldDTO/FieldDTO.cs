using Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTO.FieldDTO
{
    public class FieldDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Area { get; set; }

    }
}
