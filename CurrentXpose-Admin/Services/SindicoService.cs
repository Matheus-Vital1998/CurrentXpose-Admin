using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
{
    public class SindicoService : ISindicoService
    {
        private readonly ISindicoRepository _sindicoRepository;
        public SindicoService(ISindicoRepository sindicoRepository)
        {
            _sindicoRepository = sindicoRepository;
        }
        public Task<IReadOnlyList<Sindico>> ObterSindico()
        {
            return _sindicoRepository.GetAll();
        }
    }
}
