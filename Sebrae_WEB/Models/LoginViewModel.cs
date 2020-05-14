using System.ComponentModel.DataAnnotations;

namespace Sebrae_WEB.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string NomeUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string SenhaUsuario { get; set; }
    }
}