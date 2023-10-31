using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
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
