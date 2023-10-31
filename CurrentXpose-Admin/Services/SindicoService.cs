using System.Collections.Generic;
using System.Threading.Tasks;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public class SindicoService : ISindicoService
    {
        private readonly ISindicoRepository _sindicoRepository;

        public SindicoService(ISindicoRepository sindicoRepository)
        {
            _sindicoRepository = sindicoRepository;
        }

        public async Task<IReadOnlyList<Sindico>> ObterSindico()
        {
            return await _sindicoRepository.GetAll();
        }

        public async Task<int> InserirSindico(Sindico novoSindico)
        {
            return await _sindicoRepository.Insert(novoSindico);
        }

        public async Task<bool> AtualizarSindico(Sindico sindicoEditado)
        {
            return await _sindicoRepository.Update(sindicoEditado);
        }

        public async Task<bool> ExcluirSindico(int sindicoId)
        {
            return await _sindicoRepository.Delete(sindicoId);
        }

        public async Task<Sindico> DetalhesSindico(int sindicoId)
        {
            return await _sindicoRepository.Details(sindicoId);
        }
    }
}