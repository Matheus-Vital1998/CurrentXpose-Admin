using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Repository
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
                                dbo.Sindico.id,
                                dbo.Sindico.nome,
                                dbo.Sindico.login,
                                dbo.Sindico.senha,
                                dbo.Sindico.nivel_relatorio
                            from dbo.Sindico
                            order by nome";

                var result = await conn.QueryAsync<Sindico>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task Insert(Sindico sindico)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"INSERT INTO dbo.Sindico (nome, login, senha, condominio_id, nivel_relatorio) 
                    VALUES (@Nome, @Login, @Senha, @Condominio, @Relatorio)";

                var parameters = new
                {
                    Nome = sindico.nome,
                    Login = sindico.login,
                    Senha = sindico.senha,
                    Condominio = sindico.condominio.id,
                    Relatorio = sindico.nivel_relatorio
                };

                var result = await conn.ExecuteAsync(sql, parameters);
                conn.Close();
            }
        }

        public async Task<bool> Update(Sindico sindico)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"UPDATE dbo.Sindico
                     SET nome = @Nome,
                         login = @Login,
                         senha = @Senha,
                         condominio = @Condominio,
                         nivel_relatorio = @NivelRelatorio
                     WHERE id = @Id";

                var rowsAffected = await conn.ExecuteAsync(sql, sindico);

                conn.Close();

                return rowsAffected > 0;
            }
        }

        public async Task<bool> Delete(int sindicoId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = "DELETE FROM dbo.Sindico WHERE id = @SindicoId";
                var parameters = new { SindicoId = sindicoId };

                var rowsAffected = await conn.ExecuteAsync(sql, parameters);

                conn.Close();

                return rowsAffected > 0;
            }
        }

        public async Task<Sindico> Details(int sindicoId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = $@"SELECT
                        dbo.Sindico.id,
                        dbo.Sindico.nome,
                        dbo.Sindico.login,
                        dbo.Sindico.senha,
                        dbo.Sindico.condominio_id,
                        dbo.Sindico.nivel_relatorio
                    FROM dbo.Sindico
                    WHERE dbo.Sindico.id = @SindicoId";

                var parameters = new { SindicoId = sindicoId };

                var result = await conn.QueryFirstOrDefaultAsync<Sindico>(sql, parameters);

                conn.Close();

                return result;
            }
        }
    }
}
