using Dapper;
using Microsoft.Data.SqlClient;
using PruebaTecnicaApi.Data.Models;
using PruebaTecnicaApi.DTOs;
using PruebaTecnicaApi.Repository.Interfaces;

namespace PruebaTecnicaApi.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly IConfiguration _configuration;


        public PacienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


       


        public async Task<PacienteRequest> ActualizarPacienteAsync(int id ,PacienteRequest paciente)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("MyConnectionString")))
            {
                await con.OpenAsync();
                string query = "UPDATE Paciente SET TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, " +
                    "Correo = @Correo, Genero = @Genero, Direccion = @Direccion, NumeroTelefono = @NumeroTelefono, Activo = @Activo WHERE PacienteId = @Id";

                int rowsAffected = await con.ExecuteAsync(query, new { paciente.TipoDocumento, paciente.NumeroDocumento, 
                    paciente.Nombre, paciente.FechaNacimiento, paciente.Correo, paciente.Genero, paciente.Direccion, paciente.NumeroTelefono, paciente.Activo, Id = id });

                return paciente;
 
            }
        }

        public async Task<int> GuardarPacienteAsync(PacienteRequest paciente)
        {

            using (var con = new SqlConnection(_configuration.GetConnectionString("MyConnectionString")))
            {
                 await con.OpenAsync();
                string query = @"INSERT INTO Paciente (TipoDocumentoId, NumeroDocumento, Nombre, FechaNacimiento, Correo, GeneroId, Direccion, NumeroTelefono, Activo)
                    VALUES (@TipoDocumento, @NumeroDocumento, @Nombre, @FechaNacimiento, @Correo, @Genero, @Direccion, @NumeroTelefono, @Activo); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                return await con.ExecuteScalarAsync<int>(query, paciente);


            }

        }

        public async Task<IEnumerable<Paciente>> ListarPacientesAsync()
        {
            var sql = "SELECT Id,TipoDocumentoId,NumeroDocumento,Nombre,Activo FROM Paciente";
            using (var con = new SqlConnection(_configuration.GetConnectionString("MyConnectionString")))
            {
                await con.OpenAsync();
                var result = await con.QueryAsync<Paciente>(sql);

                return result.ToList();
            }


        }

        public async Task<Paciente> ObtenerPacientePorIdAsync(int id)
        {
            var query = "SELECT Id,TipoDocumentoId,NumeroDocumento,Nombre,Activo FROM Paciente where Id = @Id";
            using (var con = new SqlConnection(_configuration.GetConnectionString("MyConnectionString")))
            {
               await con.OpenAsync();

                return await con.QueryFirstAsync<Paciente>(query, new { Id = id });
            }

        }

       
    }
}
