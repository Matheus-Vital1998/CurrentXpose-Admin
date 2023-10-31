using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel  
    {
        Task<T> GetByIdAsync(object id);

        Task<IReadOnlyList<T>> ListAllAsync();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();

        Task InsertAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}
