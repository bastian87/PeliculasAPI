﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTO
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}
