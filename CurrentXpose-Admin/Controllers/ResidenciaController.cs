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

        public IActionResult Index()
        {
            var residencias =  _residenciaService.ObterResidencias();
            return View(residencias);
        }
    }
}
