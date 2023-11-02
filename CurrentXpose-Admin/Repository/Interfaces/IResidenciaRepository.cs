using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IResidenciaRepository : IBaseRepository<Residencia>
    {
        Task<IReadOnlyList<Residencia>> GetAll();
        Task Insert(Residencia residencia);
        Task Update(Residencia residencia);
        Task Delete(int residenciaId);
        Task<Residencia> Details(int residenciaId);
    }
}
