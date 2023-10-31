using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface IResidenciaRepository : IBaseRepository<Residencia>
    {
        Task<IReadOnlyList<Residencia>> GetAll();
    }
}
