using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    public class SindicoController : Controller
    {
        private readonly ISindicoService _sindicoService;

        public SindicoController(ISindicoService sindicoService)
        {
            _sindicoService = sindicoService;
        }

        public async Task<IActionResult> Lista()
        {
            var sindicos = await _sindicoService.ObterSindico();
            return View(sindicos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(Sindico novoSindico)
        {
            await _sindicoService.InserirSindico(novoSindico);
            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Editar(int id)
        {
            var sindico = await _sindicoService.DetalhesSindico(id);
            if (sindico == null)
            {
                return NotFound();
            }

            return View(sindico);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Sindico sindicoEditado)
        {
            if (ModelState.IsValid)
            {
                var sucesso = await _sindicoService.AtualizarSindico(sindicoEditado);

                if (sucesso)
                {
                    return RedirectToAction("Lista");
                }

                return BadRequest();
            }

            return View(sindicoEditado);
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var sindico = await _sindicoService.DetalhesSindico(id);
            if (sindico == null)
            {
                return NotFound();
            }

            return View(sindico);
        }

        public async Task <IActionResult> Excluir(int id)
        {
            var sindico = await _sindicoService.DetalhesSindico(id);
            return View(sindico);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            await _sindicoService.ExcluirSindico(id);
            return RedirectToAction("Lista");

        }
    }
}