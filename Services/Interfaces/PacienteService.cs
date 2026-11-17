using PruebaTecnicaApi.Data.Models;
using PruebaTecnicaApi.DTOs;
using PruebaTecnicaApi.Repository.Interfaces;

namespace PruebaTecnicaApi.Services.Interfaces
{
    public class PacienteService : IPacienteService
    {

        private readonly IPacienteRepository _pacienteRepository;


        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }


        public async Task<PacienteResponse> ActualizarPaciente(int id, PacienteRequest paciente)
        {



            var result = await _pacienteRepository.ActualizarPacienteAsync(id,paciente);

            var pacienteResult = new PacienteResponse
            { 
                TipoDocumento = result.TipoDocumento,
                NumeroDocumento = result.NumeroDocumento,
                Nombre = result.Nombre,
                FechaNacimiento = result.FechaNacimiento.ToString(),
                Correo = result.Correo,
                Genero = result.Genero,
                Direccion = result.Direccion,
                NumeroTelefono = result.NumeroTelefono,
                Activo = result.Activo
            };

            return pacienteResult;
        }

        public async Task<PacienteResponse> CrearPaciente(PacienteRequest paciente)
        {
           


            var result =await _pacienteRepository.GuardarPacienteAsync(paciente);

            var pacienteResult = new PacienteResponse
            {
                Id = result,
                TipoDocumento = paciente.TipoDocumento,
                NumeroDocumento = paciente.NumeroDocumento,
                Nombre = paciente.Nombre,
                FechaNacimiento = paciente.FechaNacimiento.ToString("d"),
                Correo = paciente.Correo,
                Genero = paciente.Genero,
                Direccion = paciente.Direccion,
                NumeroTelefono = paciente.NumeroTelefono,
                Activo = paciente.Activo
            };


            return pacienteResult;
        }

        public async Task<PacienteResponse> ObtenerPacientePorId(int id)
        {
            var result = await _pacienteRepository.ObtenerPacientePorIdAsync(id);

            var pacienteResult = new PacienteResponse
            {
                Id = result.Id,
                TipoDocumento = result.TipoDocumentoId,
                NumeroDocumento = result.NumeroDocumento,
                Nombre = result.Nombre,
                FechaNacimiento = result.FechaNacimiento.ToString(),
                Correo = result.Correo,
                Genero = result.GeneroId,
                Direccion = result.Direccion,
                NumeroTelefono = result.NumeroTelefono,
                Activo = result.Activo
            };

            return pacienteResult;

        }

        public async Task<List<PacienteListResponse>> ObtenerPacientes()
        {
            var result = await _pacienteRepository.ListarPacientesAsync();


          var pacienteResult =   result.Select( result => new PacienteListResponse
            {
                Id = result.Id,
                TipoDocumento = result.TipoDocumentoId,
                NumeroDocumento = result.NumeroDocumento,
                Nombre = result.Nombre,
                Activo = result.Activo
            }).ToList();

            return pacienteResult;
        }
    }
}
