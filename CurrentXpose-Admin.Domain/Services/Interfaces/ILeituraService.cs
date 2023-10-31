using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface ILeituraService
    {
        Task<IReadOnlyList<Leitura>> ObterDadosDeLeitura();
    }
}
