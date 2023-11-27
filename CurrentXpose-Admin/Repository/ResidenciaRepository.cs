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
                                dbo.Residencia.predio_id
                            from dbo.Residencia
                            order by numero";

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

                var sql = $@"INSERT INTO dbo.Residencia (numero, andar, predio_id)
                     VALUES (@Numero, @Andar, @PredioId)";

                await conn.ExecuteAsync(sql, new
                {
                    Numero = residencia.numero,
                    Andar = residencia.andar,
                    PredioId = residencia.predio_id
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
                         predio_id = @PredioId
                     WHERE id = @ResidenciaId";

                await conn.ExecuteAsync(sql, new
                {
                    Numero = residencia.numero,
                    Andar = residencia.andar,
                    PredioId = residencia.predio.id,
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
                        r.predio_id 
                    FROM dbo.Residencia r
                    WHERE r.id = @ResidenciaId";

                var parameters = new { ResidenciaId = residenciaId };

                var result = await conn.QueryFirstOrDefaultAsync<Residencia>(sql, parameters);

                conn.Close();

                return result;
            }
        }
    }
}
