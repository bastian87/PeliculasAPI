namespace PeliculasAPI.Servicios
{
    public class AlmacenadorArchivosLocal : IAlmacenadorArchivos
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AlmacenadorArchivosLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env; // Vamos a poder obtener la ruta donde se encuentra nuestro wwwRoot, para asi poder colocar archivos en la carpeta.
            this.httpContextAccessor = httpContextAccessor; // Vamos a poder determinar el dominio donde tenemos publicada nuestra WebAPI, para poder construir le URL sobre la cual se va a guardar en la tabla de actores.
        }
        public Task DeleteArchivo(string ruta, string contenedor)
        {
            if(ruta != null)
            {
                var nombreArchivo = Path.GetFileName(ruta);
                string directorioArchivo = Path.Combine(env.WebRootPath, nombreArchivo);

                if(File.Exists(directorioArchivo))
                {
                    File.Delete(directorioArchivo);
                }
            }

            return Task.FromResult(0);
        }

        public async Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contentType)
        {
            await DeleteArchivo(ruta, contenedor);
            return await GuardarArchivo(contenido, extension, contenedor, contentType);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contentType)
        {
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, contenedor);

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);
            await File.WriteAllBytesAsync(ruta, contenido); // Estamos escribiendo en el HDD el contenido del archivo.

            // Con esto tenemos el dominio.
            var urlActual = $"{httpContextAccessor.HttpContext.Request.Scheme} ://{httpContextAccessor.HttpContext.Request.Host}";
            var urlParaDB = Path.Combine(urlActual, contenedor, nombreArchivo).Replace("\\", "/");
            
            return urlParaDB;


        }
    }
}
