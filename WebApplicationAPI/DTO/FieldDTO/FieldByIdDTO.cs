﻿using Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTO.FieldDTO
{
    public class FieldByIdDTO
    {
        
        [StringLength(50)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Area { get; set; }

        public List<Flower> Flowers { get; set; }

    }
}
