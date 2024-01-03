using Microsoft.Extensions.Options;

namespace PeliculasAPI.DTO
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;

        private int cantidadRegistrosPorPagina = 10;
        private readonly int cantidadMaximaRegistrosPorPagina = 50;

        public int CantidadRegistrosPorPagina 
        { 
            get => CantidadRegistrosPorPagina; 
            set
            {
                cantidadRegistrosPorPagina = (value > cantidadMaximaRegistrosPorPagina) ? cantidadMaximaRegistrosPorPagina: value;
            } 
        }
    }
}
