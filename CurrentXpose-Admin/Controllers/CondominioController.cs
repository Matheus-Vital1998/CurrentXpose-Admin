using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    public class CondominioController : Controller
    {
        private readonly ICondominioService _condominioService;

        public CondominioController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }
        public async Task<IActionResult> Lista()
        {
            var condominios =  await _condominioService.ObterCondominios();
            return View(condominios);
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
