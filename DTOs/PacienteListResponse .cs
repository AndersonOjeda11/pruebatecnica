using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaApi.DTOs
{
    public class PacienteListResponse
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
        public bool Activo { get; set; }
    }
}
