using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task InserirResidencia(Residencia novaResidencia)
        {
            return _residenciaRepository.Insert(novaResidencia);
        }

        public Task AtualizarResidencia(Residencia residenciaEditada)
        {
            return _residenciaRepository.Update(residenciaEditada);
        }

        public Task ExcluirResidencia(int residenciaId)
        {
            return _residenciaRepository.Delete(residenciaId);
        }

        public Task<Residencia> DetalhesResidencia(int residenciaId)
        {
            return _residenciaRepository.Details(residenciaId);
        }
    }
}