namespace TesteTradeTechnology.CrossCutting.Interfaces.Services
{
    public interface ICampeonatoService
    {
        Task<Domain.Campeonatos.Campeonato> SimularCampeonato();
    }
}