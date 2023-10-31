using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class LeituraService : ILeituraService
    {
        private readonly ILeituraRepository _leituraRepository;

        public LeituraService(ILeituraRepository leituraRepository)
        {
            _leituraRepository = leituraRepository;
        }

        public Task<IReadOnlyList<Leitura>> ObterDadosDeLeitura()
        {
            return _leituraRepository.GetAll();
        }
    }
}
