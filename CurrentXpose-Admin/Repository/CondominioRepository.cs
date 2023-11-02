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

        public async Task Insert(Condominio condominio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"INSERT INTO dbo.Condominio (nome)
                     VALUES (@Nome)";

                await conn.ExecuteAsync(sql, new { Nome = condominio.nome });

                conn.Close();
            }
        }

        public async Task Update(Condominio condominio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"UPDATE dbo.Condominio
                     SET nome = @Nome
                     WHERE id = @Id";

                await conn.ExecuteAsync(sql, new { Nome = condominio.nome, Id = condominio.id });

                conn.Close();
            }
        }

        public async Task Delete(int condominioId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = "DELETE FROM dbo.Condominio WHERE id = @CondominioId";

                await conn.ExecuteAsync(sql, new { CondominioId = condominioId });

                conn.Close();
            }
        }

        public async Task<Condominio> Details(int condominioId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = "SELECT id, nome FROM dbo.Condominio WHERE id = @CondominioId";

                var result = await conn.QueryFirstOrDefaultAsync<Condominio>(sql, new { CondominioId = condominioId });

                conn.Close();

                return result;
            }
        }
    }
}
