using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTO
{
    public class ActorDTO
    {
        public int id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
