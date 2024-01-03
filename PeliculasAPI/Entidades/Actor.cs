using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Actor
    {
        public int id {  get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; } // Vamos a guardar la URL de la foto de la persona. La vamos a guardar en Azure Storage o en el Local Storage
        public List<PeliculasActores> peliculasActores { get; set; }
    }
}
