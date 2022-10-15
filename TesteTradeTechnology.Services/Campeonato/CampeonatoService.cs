using TesteTradeTechnology.CrossCutting.Interfaces.Context;
using TesteTradeTechnology.CrossCutting.Interfaces.Services;
using TesteTradeTechnology.Domain.Campeonatos;
using TesteTradeTechnology.Domain.Jogos;
using TesteTradeTechnology.Domain.Placares;
using TesteTradeTechnology.Domain.Times;

namespace TesteTradeTechnology.Services.Campeonato
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly IMeuCampeonatoContext _context;

        public CampeonatoService(IMeuCampeonatoContext context)
        {
            _context = context;
        }

        public async Task<Domain.Campeonatos.Campeonato> SimularCampeonato()
        {

            var campeonatos = _context.Campeonatos.Count();

            var campeonato = new Domain.Campeonatos.Campeonato()
            {
                Nome = "Campeonato numero " + (campeonatos + 1)
            };

            _context.Campeonatos.Add(campeonato);
            _context.SaveChanges();

            List<Jogo> jogosQuartasDeFinal = await GerarJogos(campeonato.Id);

            List<Time> vencedoresQuartasDeFinal = await ObterVencedores(jogosQuartasDeFinal);

            var jogosSemiFinal = await GerarJogos(campeonato.Id, vencedoresQuartasDeFinal);
            var vencedoresSemiFinal = await ObterVencedores(jogosSemiFinal);

            var jogoFinal = await GerarJogos(campeonato.Id, vencedoresSemiFinal);
            var vencedor = await ObterVencedores(jogoFinal);

            campeonato = _context.Campeonatos.Find(campeonato.Id);
            foreach(var jogo in campeonato.Jogos)
            {
                jogo.Campeonato = null;
            }
            return campeonato;

        }

        private async Task<List<Time>> ObterVencedores(List<Jogo> jogos)
        {

            List<Time> vencedores = new();

            foreach (Jogo jogo in jogos)
            {
                var placar = jogo.Placar;

                Time timeVencedor = await ObterVencedor(placar);
                vencedores.Add(timeVencedor);
            }

            return vencedores;
        }

        private async Task<List<Jogo>> GerarJogos(int idCampeonato, List<Time>? times = null)
        {
            try
            {
                if (times == null || times.Count <= 0)
                {
                    times = await ObterTimes();
                }

                List<Jogo> jogos = new();

                for (int i = 0; i < times.Count; i += 2)
                {
                    var timeA = times[i];
                    var timeB = times[i + 1];
                    var placar = await GerarPlacar(timeA, timeB);
                    jogos.Add(new Jogo { Placar = placar, IdPlacar = placar.Id, IdCampeonato = idCampeonato });
                }

                _context.Jogos.AddRange(jogos);
                _context.SaveChanges();

                return jogos;

            }
            catch
            {
                throw;
            }

        }

        private async Task<Time> ObterVencedor(Placar placar)
        {
            if (placar.PontosTimeA > placar.PontosTimeB)
                return placar.TimeA;
            else if (placar.PontosTimeA < placar.PontosTimeB)
                return placar.TimeB;

            return await ObterVencedor(await GerarPlacar(placar.TimeA, placar.TimeB));

        }

        private Task<Placar> GerarPlacar(Time timeA, Time timeB)
        {
            try
            {
                Random random = new();

                int pontosTimeA = random.Next(0, 8);
                int pontosTimeB = random.Next(0, 8);

                var placar = new Placar
                {
                    IdTimeA = timeA.Id,
                    TimeA = timeA,
                    PontosTimeA = pontosTimeA,
                    IdTimeB = timeB.Id,
                    TimeB = timeB,
                    PontosTimeB = pontosTimeB,
                };

                _context.Placares.Add(placar);
                _context.SaveChanges();

                return Task.FromResult(placar);
            }
            catch
            {
                throw;
            }
        }

        private Task<List<Time>> ObterTimes()
        {
            return Task.FromResult(_context.Times.ToList());
        }
    }
}
