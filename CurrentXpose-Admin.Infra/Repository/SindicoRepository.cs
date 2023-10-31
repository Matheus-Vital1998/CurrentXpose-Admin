using CurrentXpose_Admin.Domain.Entidades;
using CurrentXpose_Admin.Infra.Repository.Interfaces;
using CurrentXpose_Admin.Infra.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Infra.Repository
{
    public class SindicoRepository : BaseRepository<Sindico> , ISindicoRepository
    {
        public SindicoRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Sindico>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                nome,
                                login,
                                senha,
                                nivel_relatorio
                            from dbo.Sindico
                            order by nome";

                var result = await conn.QueryAsync<Sindico>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
