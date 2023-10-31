using CurrentXpose_Admin.Domain.Entidades;
using CurrentXpose_Admin.Infra.Context;
using CurrentXpose_Admin.Infra.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Infra.Repository
{
    public class LeituraRepository : BaseRepository<Leitura>, ILeituraRepository
    {
        public LeituraRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Leitura>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                data_da_leitura,
                                valor_da_leitura
                            from dbo.Leitura";

                var result = await conn.QueryAsync<Leitura>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
