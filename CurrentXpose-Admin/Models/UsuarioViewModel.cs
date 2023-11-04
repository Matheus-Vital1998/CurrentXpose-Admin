using System.ComponentModel.DataAnnotations;

namespace CurrentXpose_Admin.Models
{
    public class UsuarioViewModel
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
    }
}
