using CurrentXpose_Admin.Domain.Entidades;
using CurrentXpose_Admin.Infra.Repository.Interfaces;
using CurrentXpose_Admin.Infra.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Infra.Repository
{
    public class ResidenciaRepository : BaseRepository<Residencia> , IResidenciaRepository
    {
        public ResidenciaRepository(CurrentXposeAdminContext context) : base(context) { }

        public async Task<IReadOnlyList<Residencia>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                numero,
                                andar
                            from dbo.Residencia";

                var result = await conn.QueryAsync<Residencia>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
