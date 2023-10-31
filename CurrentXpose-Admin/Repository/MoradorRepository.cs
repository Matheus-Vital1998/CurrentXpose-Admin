using Dapper;
using Microsoft.EntityFrameworkCore;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;

namespace CurrentXpose_Admin.Repository
{
    public class MoradorRepository : BaseRepository<Morador>, IMoradorRepository
    {
        public MoradorRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Morador>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                nome,
                                login,
                                senha
                            from dbo.Morador
                            order by nome";

                var result = await conn.QueryAsync<Morador>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
