using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface ILeituraRepository : IBaseRepository<Leitura>
    {
        Task<IReadOnlyList<Leitura>> GetAll();
    }
}

