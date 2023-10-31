using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IMoradorService
    {
        Task<IReadOnlyList<Morador>> ObterMoradores();
        Task InserirMorador(Morador novoMorador);
        Task AtualizarMorador(Morador moradorEditado);
        Task ExcluirMorador(int moradorId);
        Task<Morador> DetalhesMorador(int moradorId);
    }
}
