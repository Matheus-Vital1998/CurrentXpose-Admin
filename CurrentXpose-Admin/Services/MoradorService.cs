using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;
        public MoradorService(IMoradorRepository moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }
        public Task<IReadOnlyList<Morador>> ObterMoradores()
        {
            return _moradorRepository.GetAll();
        }
    }
}
