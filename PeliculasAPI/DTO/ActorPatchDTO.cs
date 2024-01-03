using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTO
{
    public class ActorPatchDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
