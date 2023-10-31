using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class ResidenciaService : IResidenciaService
    {
        private readonly IResidenciaRepository _residenciaRepository;

        public ResidenciaService(IResidenciaRepository residenciaRepository)
        {
            _residenciaRepository = residenciaRepository;
        }

        public Task<IReadOnlyList<Residencia>> ObterResidencias()
        {
            return _residenciaRepository.GetAll();
        }
    }
}
