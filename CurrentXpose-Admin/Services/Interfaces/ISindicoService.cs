using System.Collections.Generic;
using System.Threading.Tasks;
using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface ISindicoService
    {
        Task<IReadOnlyList<Sindico>> ObterSindico();
        Task<int> InserirSindico(Sindico novoSindico);
        Task<bool> AtualizarSindico(Sindico sindicoEditado);
        Task<bool> ExcluirSindico(int sindicoId);
        Task<Sindico> DetalhesSindico(int sindicoId);
    }
}