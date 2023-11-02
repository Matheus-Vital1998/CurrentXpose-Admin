using Dapper;
using Microsoft.EntityFrameworkCore;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Context;
using System.Threading.Tasks;
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
                                dbo.Morador.residencia_id,
                                dbo.Morador.pergunta,
                                dbo.Morador.resposta
                            from dbo.Morador
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

                var sql = @"INSERT INTO dbo.Morador (nome, login, senha, pergunta, resposta, residencia_id) 
                    VALUES (@Nome, @Login, @Senha, @Pergunta, @Resposta, @Residencia)";

                var parameters = new
                {
                    Nome = novoMorador.nome,
                    Login = novoMorador.login,
                    Senha = novoMorador.senha,
                    Pergunta = novoMorador.pergunta,
                    Resposta = novoMorador.resposta,
                    Residencia = novoMorador.residencia.id
                };

                var result = await conn.ExecuteAsync(sql, parameters);
                conn.Close();
            }
        }

        public async Task Update(Morador moradorEditado)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                var residenciaExistente = await conn.QueryFirstOrDefaultAsync<Residencia>(
                    "SELECT * FROM dbo.Residencia WHERE id = @ResidenciaId",
                    new { ResidenciaId = moradorEditado.residencia.id }
                );

                if (residenciaExistente == null)
                {
                    throw new InvalidOperationException("A Residencia com o id correspondente não existe.");
                }

                var sql = @"UPDATE dbo.Morador 
                    SET nome = @Nome, 
                        login = @Login, 
                        senha = @Senha,
                        pergunta = @Pergunta,
                        resposta = @Resposta,
                        residencia_id = @ResidenciaId
                    WHERE id = @MoradorId";

                await conn.ExecuteAsync(sql, new
                {
                    Nome = moradorEditado.nome,
                    Login = moradorEditado.login,
                    Senha = moradorEditado.senha,
                    Pergunta = moradorEditado.pergunta,
                    Resposta = moradorEditado.resposta,
                    ResidenciaId = moradorEditado.residencia.id,
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

                var sql = @"SELECT id, nome, login, senha, pergunta, resposta, residencia_id 
                    FROM dbo.Morador 
                    WHERE id = @MoradorId";

                var result = await conn.QueryFirstOrDefaultAsync<Morador>(sql, new { MoradorId = moradorId });

                conn.Close();

                return result;
            }
        }
    }
}
