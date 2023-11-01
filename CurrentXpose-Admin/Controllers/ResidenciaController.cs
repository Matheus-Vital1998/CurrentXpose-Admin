using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
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
            return RedirectToAction(nameof(Lista));
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Residencia residenciaEditada)
        {
            await _residenciaService.AtualizarResidencia(residenciaEditada);
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Detalhes(int residenciaId)
        {
            var residencia = await _residenciaService.DetalhesResidencia(residenciaId);
            return View(residencia);
        }

        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int residenciaId)
        {
            await _residenciaService.ExcluirResidencia(residenciaId);
            return RedirectToAction(nameof(Lista));
        }
    }
}