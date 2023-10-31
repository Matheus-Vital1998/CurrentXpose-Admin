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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }
    }
}
