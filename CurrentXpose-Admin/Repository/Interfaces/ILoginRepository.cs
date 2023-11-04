using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Usuario> GetLogin(string login);
    }
}
