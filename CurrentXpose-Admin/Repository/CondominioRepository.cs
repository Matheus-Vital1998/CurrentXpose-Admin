using Dapper;
using Microsoft.EntityFrameworkCore;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Context;
using CurrentXpose_Admin.Repository.Interfaces;

namespace CurrentXpose_Admin.Repository
{
    public class CondominioRepository : BaseRepository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Condominio>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                nome 
                            from dbo.Condominio
                            order by nome";

                var result = await conn.QueryAsync<Condominio>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
