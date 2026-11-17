using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaApi.DTOs
{
    public class PacienteResponse
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public int TipoDocumento { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string FechaNacimiento { get; set; }
        [Required]
        public string Correo { get; set; } = string.Empty;
        [Required]
        public int Genero { get; set; }
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string NumeroTelefono { get; set; } = string.Empty;
        [Required]
        public bool Activo { get; set; }
    }
}
