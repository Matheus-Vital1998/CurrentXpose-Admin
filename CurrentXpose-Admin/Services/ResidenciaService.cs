using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
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
