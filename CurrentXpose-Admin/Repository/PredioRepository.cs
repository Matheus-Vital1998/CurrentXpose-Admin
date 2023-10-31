using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Repository
{
    public class PredioRepository : BaseRepository<Predio> , IPredioRepository
    {
        public PredioRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Predio>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                nome,
                                total_de_andares
                            from dbo.Predio
                            order by nome";

                var result = await conn.QueryAsync<Predio>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
