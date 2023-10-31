using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominioRepository _condominioRepository;
        public CondominioService(ICondominioRepository condominioRepository) 
        {
            _condominioRepository = condominioRepository;
        }
        public Task<IReadOnlyList<Condominio>> ObterCondominios()
        {
            return  _condominioRepository.GetAll();
        }
    }
}
