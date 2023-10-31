using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class PredioService : IPredioService
    {
        private readonly IPredioRepository _predioRepository;
        public PredioService(IPredioRepository predioRepository) 
        {
            _predioRepository = predioRepository;
        }
        public Task<IReadOnlyList<Predio>> ObterPredios()
        {
            return _predioRepository.GetAll();
        }
    }
}
