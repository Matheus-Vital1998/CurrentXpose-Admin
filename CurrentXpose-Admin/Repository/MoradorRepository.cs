using Dapper;
using Microsoft.EntityFrameworkCore;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;

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
                                dbo.Morador.id,
                                dbo.Morador.nome,
                                dbo.Morador.login,
                                dbo.Morador.senha,
                                dbo.Residencia.numero,
                                dbo.Residencia.andar
                            from dbo.Morador
                            INNER JOIN dbo.Residencia on Morador.residencia = Residencia.Id
                            order by nome";
                var result = await conn.QueryAsync<Morador>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task Insert(Morador novoMorador)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"INSERT INTO dbo.Morador (nome, login, senha, residencia) 
                    VALUES (@Nome, @Login, @Senha, @Residencia)";

                await conn.ExecuteAsync(sql, new
                {
                    Nome = novoMorador.nome,
                    Login = novoMorador.login,
                    Senha = novoMorador.senha,
                    Residencia = novoMorador.residencia
                });

                conn.Close();
            }
        }

        public async Task Update(Morador moradorEditado)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"UPDATE dbo.Morador 
                    SET nome = @Nome, 
                        login = @Login, 
                        senha = @Senha,
                        residencia = @residencia
                    WHERE id = @MoradorId";

                await conn.ExecuteAsync(sql, new
                {
                    Nome = moradorEditado.nome,
                    Login = moradorEditado.login,
                    Senha = moradorEditado.senha,
                    Residencia = moradorEditado.residencia,
                    MoradorId = moradorEditado.id
                });
                conn.Close();
            }
        }

        public async Task Delete(int moradorId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"DELETE FROM dbo.Morador 
                    WHERE id = @MoradorId";

                await conn.ExecuteAsync(sql, new { MoradorId = moradorId });

                conn.Close();
            }
        }

        public async Task<Morador> Details(int moradorId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var sql = @"SELECT id, nome, login, senha, residencia 
                    FROM dbo.Morador 
                    WHERE id = @MoradorId";

                var result = await conn.QueryFirstOrDefaultAsync<Morador>(sql, new { MoradorId = moradorId });

                conn.Close();

                return result;
            }
        }
    }
}
