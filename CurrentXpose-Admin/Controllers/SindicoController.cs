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

        public IActionResult Index()
        {
            var sindico =  _sindicoService.ObterSindico();
            return View(sindico);
        }
    }
}
