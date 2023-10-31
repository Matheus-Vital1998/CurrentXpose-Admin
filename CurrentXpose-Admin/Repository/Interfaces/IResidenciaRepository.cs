using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IResidenciaRepository : IBaseRepository<Residencia>
    {
        Task<IReadOnlyList<Residencia>> GetAll();
    }
}
