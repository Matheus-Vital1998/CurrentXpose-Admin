using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    [Authorize]
    public class ResidenciaController : Controller
    {
        private readonly IResidenciaService _residenciaService;

        public ResidenciaController(IResidenciaService residenciaService)
        {
            _residenciaService = residenciaService;
        }

        public async Task<IActionResult> Lista()
        {
            var residencias = await _residenciaService.ObterResidencias();
            return View(residencias);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(Residencia novaResidencia)
        {
            await _residenciaService.InserirResidencia(novaResidencia);
            return RedirectToAction("Lista");
        }

        public async Task <IActionResult> Editar(int id)
        {
            var residencia = await _residenciaService.DetalhesResidencia(id);
            return View(residencia);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Residencia residenciaEditada)
        {
            await _residenciaService.AtualizarResidencia(residenciaEditada);
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var residencia = await _residenciaService.DetalhesResidencia(id);
            return View(residencia);
        }

        public async Task <IActionResult> Excluir(int id)
        {
            var residencia = await _residenciaService.DetalhesResidencia(id);
            return View(residencia);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            await _residenciaService.ExcluirResidencia(id);
            return RedirectToAction(nameof(Lista));
        }
    }
}