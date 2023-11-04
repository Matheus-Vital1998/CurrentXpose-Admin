using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Models;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace CurrentXposeAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(UsuarioViewModel usuario)
        {
            var result = await _loginService.AutenticacaoAdmin(usuario, ModelState);

            if (result == "Success")
            {
                return RedirectToAction("Inicial", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = result;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Inicial()
        {
            return View();
        }
    }
}
