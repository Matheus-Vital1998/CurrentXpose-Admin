using CurrentXpose_Admin.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> AutenticacaoAdmin(UsuarioViewModel usuario, ModelStateDictionary modelState);
    }
}
