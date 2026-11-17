using PruebaTecnicaApi.Data.Models;
using PruebaTecnicaApi.DTOs;

namespace PruebaTecnicaApi.Repository.Interfaces
{
    public interface IPacienteRepository
    {

        Task<IEnumerable<Paciente>> ListarPacientesAsync();
        Task<int> GuardarPacienteAsync(PacienteRequest paciente);
        Task<Paciente> ObtenerPacientePorIdAsync(int id);
        Task<PacienteRequest> ActualizarPacienteAsync(int id ,PacienteRequest paciente);
    }
}
