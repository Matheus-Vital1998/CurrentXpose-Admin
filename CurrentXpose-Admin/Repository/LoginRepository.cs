using CurrentXpose_Admin.Context;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly CurrentXposeAdminContext _context;

        public LoginRepository(CurrentXposeAdminContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetLogin(string login)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = "SELECT id, login, senha FROM dbo.Admin WHERE login = @UsuarioLogin";

                var result = await conn.QueryFirstOrDefaultAsync<Usuario>(sql, new { UsuarioLogin = login });

                conn.Close();

                return result;
            }
        }
    }
}
