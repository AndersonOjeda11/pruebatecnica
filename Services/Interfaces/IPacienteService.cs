using PruebaTecnicaApi.Data.Models;
using PruebaTecnicaApi.DTOs;

namespace PruebaTecnicaApi.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<PacienteListResponse>> ObtenerPacientes();
        Task<PacienteResponse> ObtenerPacientePorId(int id);
        Task<PacienteResponse> CrearPaciente(PacienteRequest paciente);
        Task<PacienteResponse> ActualizarPaciente(int id , PacienteRequest paciente);
    }
}
