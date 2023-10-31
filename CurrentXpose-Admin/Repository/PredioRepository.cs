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
                                dbo.Predio.id,
                                dbo.Predio.nome,
                                dbo.Predio.total_de_andares,
                                dbo.Condominio.nome
                            from dbo.Predio
                            INNER JOIN dbo.Condominio on dbo.Predio.condominio = dbo.Condominio.id
                            order by nome";

                var result = await conn.QueryAsync<Predio>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task Insert(Predio predio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"INSERT INTO dbo.Predio (nome, total_de_andares, condominio)
                    VALUES (@Nome, @TotalDeAndares, @CondominioId)";

                await conn.ExecuteAsync(sql, new
                {
                    Nome = predio.nome,
                    TotalDeAndares = predio.total_de_andares,
                    CondominioId = predio.condominio
                });

                conn.Close();
            }
        }

        public async Task Update(Predio predio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"UPDATE dbo.Predio
                    SET nome = @Nome,
                        total_de_andares = @TotalDeAndares,
                        condominio = @CondominioId
                    WHERE id = @PredioId";

                await conn.ExecuteAsync(sql, new
                {
                    Nome = predio.nome,
                    TotalDeAndares = predio.total_de_andares,
                    CondominioId = predio.condominio,
                    PredioId = predio.id
                });

                conn.Close();
            }
        }

        public async Task Delete(int predioId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"DELETE FROM dbo.Predio
                    WHERE id = @PredioId";

                await conn.ExecuteAsync(sql, new { PredioId = predioId });

                conn.Close();
            }
        }

        public async Task<Predio> Details(int predioId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"SELECT
                        dbo.Predio.id,
                        dbo.Predio.nome,
                        dbo.Predio.total_de_andares,
                        dbo.Predio.condominio
                    FROM dbo.Predio
                    WHERE dbo.Predio.id = @PredioId";

                var result = await conn.QueryFirstOrDefaultAsync<Predio>(sql, new { PredioId = predioId });

                conn.Close();

                return result;
            }
        }
    }
}
