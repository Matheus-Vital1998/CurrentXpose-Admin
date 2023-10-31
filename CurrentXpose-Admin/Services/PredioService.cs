using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
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
