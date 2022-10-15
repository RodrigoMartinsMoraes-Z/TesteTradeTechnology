using AutoMapper;

using Microsoft.EntityFrameworkCore;

using TesteTradeTechnology.Context;
using TesteTradeTechnology.CrossCutting.Interfaces.Context;
using TesteTradeTechnology.CrossCutting.Interfaces.Services;
using TesteTradeTechnology.Domain.Campeonatos;
using TesteTradeTechnology.Domain.Jogos;
using TesteTradeTechnology.Domain.Placares;
using TesteTradeTechnology.Domain.Times;
using TesteTradeTechnology.Models.Campeonatos;
using TesteTradeTechnology.Models.Jogos;
using TesteTradeTechnology.Models.Placares;
using TesteTradeTechnology.Models.Times;
using TesteTradeTechnology.Services.Campeonato;

var builder = WebApplication.CreateBuilder(args);


string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(projectPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOptions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IMeuCampeonatoContext, MeuCampeonatoContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("MeuCampeonato"), b => b.MigrationsAssembly("TesteTradeTechnology.Context"));
    },
    ServiceLifetime.Scoped);

builder.Services.AddScoped<ICampeonatoService, CampeonatoService>();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CampeonatoModel, Campeonato>();
    cfg.CreateMap<Campeonato, CampeonatoModel>();

    cfg.CreateMap<JogoModel, Jogo>();
    cfg.CreateMap<Jogo, JogoModel>();

    cfg.CreateMap<PlacarModel, Placar>();
    cfg.CreateMap<Placar, PlacarModel>();

    cfg.CreateMap<TimeModel, Time>();
    cfg.CreateMap<Time, TimeModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
