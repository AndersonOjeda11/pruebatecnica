using Microsoft.OpenApi;
using PruebaTecnicaApi.Repository;
using PruebaTecnicaApi.Repository.Interfaces;
using PruebaTecnicaApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});



string corsAngularPoliticy = "_corsAngularPoliticy";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsAngularPoliticy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(corsAngularPoliticy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
