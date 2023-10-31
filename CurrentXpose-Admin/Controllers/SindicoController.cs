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
            var sindico = await _sindicoService.ObterSindico();
            return View(sindico);
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
