using System.Collections.Generic;
using System.Threading.Tasks;
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;

namespace CurrentXpose_Admin.Services
{
    public class PredioService : IPredioService
    {
        private readonly IPredioRepository _predioRepository;

        public PredioService(IPredioRepository predioRepository)
        {
            _predioRepository = predioRepository;
        }

        public Task<IReadOnlyList<Predio>> ObterPredios()
        {
            return _predioRepository.GetAll();
        }

        public Task InserirPredio(Predio novoPredio)
        {
            return _predioRepository.Insert(novoPredio);
        }

        public Task AtualizarPredio(Predio predioEditado)
        {
            return _predioRepository.Update(predioEditado);
        }

        public Task ExcluirPredio(int predioId)
        {
            return _predioRepository.Delete(predioId);
        }

        public Task<Predio> DetalhesPredio(int predioId)
        {
            return _predioRepository.Details(predioId);
        }
    }
}





