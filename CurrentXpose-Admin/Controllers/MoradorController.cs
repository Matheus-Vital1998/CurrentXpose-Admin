using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    public class MoradorController : Controller
    {
        private readonly IMoradorService _moradorService;

        public MoradorController(IMoradorService moradorService)
        {
            _moradorService = moradorService;
        }

        public IActionResult Index()
        {
            var moradores =  _moradorService.ObterMoradores();
            return View(moradores);
        }
    }
}
