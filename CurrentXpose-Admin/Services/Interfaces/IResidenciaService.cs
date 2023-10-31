using System.Collections.Generic;
using System.Threading.Tasks;
using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IResidenciaService
    {
        Task<IReadOnlyList<Residencia>> ObterResidencias();
        Task InserirResidencia(Residencia novaResidencia);
        Task AtualizarResidencia(Residencia residenciaEditada);
        Task ExcluirResidencia(int residenciaId);
        Task<Residencia> DetalhesResidencia(int residenciaId);
    }
}