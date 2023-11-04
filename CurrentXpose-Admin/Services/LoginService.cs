using CurrentXpose_Admin.Models;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CurrentXpose_Admin.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<string> AutenticacaoAdmin(UsuarioViewModel usuario, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var user = await _loginRepository.GetLogin(usuario.login);

                if (user == null)
                {
                    return "Usuário não cadastrado";
                }
                else if (user.senha != usuario.senha)
                {
                    return "Credenciais inválidas!";
                }
                else
                {
                    return "Success";
                }
            }
            else
            {
                return modelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();
            }
        }
    }
}
