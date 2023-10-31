using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominioRepository _condominioRepository;

        public CondominioService(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }

        public async Task<IReadOnlyList<Condominio>> ObterCondominios()
        {
            return await _condominioRepository.GetAll();
        }

        public async Task InserirCondominio(Condominio condominio)
        {
             await _condominioRepository.InsertAsync(condominio);
        }

        public async Task AtualizarCondominio(Condominio condominio)
        {
            await _condominioRepository.Update(condominio);
        }

        public async Task ExcluirCondominio(int condominioId)
        {
            await _condominioRepository.Delete(condominioId);
        }

        public async Task<Condominio> DetalhesCondominio(int condominioId)
        {
            return await _condominioRepository.Details(condominioId);
        }
    }
}