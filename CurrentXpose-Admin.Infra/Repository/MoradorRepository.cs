using Dapper;
using Microsoft.EntityFrameworkCore;
using CurrentXpose_Admin.Domain.Entidades;
using CurrentXpose_Admin.Infra.Repository.Interfaces;
using CurrentXpose_Admin.Infra.Context;

namespace CurrentXpose_Admin.Infra.Repository
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
