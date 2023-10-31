using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Repository
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
                                dbo.Residencia.id,
                                dbo.Residencia.numero,
                                dbo.Residencia.andar,
                                dbo.Predio.id,
                                dbo.Predio.nome,
                                dbo.Predio.total_de_andares,
                                dbo.Condominio.nome
                            from dbo.Residencia
                            INNER JOIN dbo.Predio on dbo.Residencia.predio = dbo.Predio.id,
                            INNER JOIN dbo.Condominio on dbo.Predio.condominio = dbo.Condominio.id
                            order by nome";

                var result = await conn.QueryAsync<Residencia>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }

        }

        public async Task Insert(Residencia residencia)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"INSERT INTO dbo.Residencia (numero, andar, predio)
                     VALUES (@Numero, @Andar, @PredioId)";

                await conn.ExecuteAsync(sql, new
                {
                    Numero = residencia.numero,
                    Andar = residencia.andar,
                    PredioId = residencia.predio
                });

                conn.Close();
            }
        }

        public async Task Update(Residencia residencia)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"UPDATE dbo.Residencia
                     SET numero = @Numero,
                         andar = @Andar,
                         predio = @PredioId
                     WHERE id = @ResidenciaId";

                await conn.ExecuteAsync(sql, new
                {
                    Numero = residencia.numero,
                    Andar = residencia.andar,
                    PredioId = residencia.predio,
                    ResidenciaId = residencia.id
                });

                conn.Close();
            }
        }
        public async Task Delete(int residenciaId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"DELETE FROM dbo.Residencia WHERE id = @ResidenciaId";

                await conn.ExecuteAsync(sql, new { ResidenciaId = residenciaId });

                conn.Close();
            }
        }

        public async Task<Residencia> Details(int residenciaId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"SELECT
                        r.id,
                        r.numero,
                        r.andar,
                        r.predio 
                    FROM dbo.Residencia r
                    WHERE r.id = @ResidenciaId";

                var result = await conn.QueryFirstOrDefaultAsync<Residencia>(sql, new { ResidenciaId = residenciaId });

                conn.Close();

                return result;
            }
        }
    }
}
