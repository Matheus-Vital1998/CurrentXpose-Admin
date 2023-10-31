using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }

        public Task<IReadOnlyList<Morador>> ObterMoradores()
        {
            return _moradorRepository.GetAll();
        }

        public async Task InserirMorador(Morador novoMorador)
        {
            await _moradorRepository.Insert(novoMorador);
        }

        public async Task AtualizarMorador(Morador moradorEditado)
        {
            await _moradorRepository.Update(moradorEditado);
        }

        public async Task ExcluirMorador(int moradorId)
        {
            await _moradorRepository.Delete(moradorId);
        }

        public async Task<Morador> DetalhesMorador(int moradorId)
        {
            return await _moradorRepository.Details(moradorId);
        }
    }
}






