using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Models;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CurrentXposeAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
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
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.login),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Inicial", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = result;
                return RedirectToAction("Index", "Login");
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [Authorize]
        public IActionResult Inicial()
        {
            _logger.LogInformation("Acesso bem-sucedido. Redirecionando para a tela inicial.");
            return View();
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
