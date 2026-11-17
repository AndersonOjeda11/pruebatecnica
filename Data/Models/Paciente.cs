namespace PruebaTecnicaApi.Data.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; } 
        public string Correo { get; set; } = string.Empty;
        public int GeneroId { get; set; }

        public string Direccion { get; set; } = string.Empty;
        public string NumeroTelefono { get; set; } = string.Empty;
        public bool Activo { get; set; }


    }
}
