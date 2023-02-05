using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class PensadorPostModel
    {
        [Required(ErrorMessage = "Os dados do usuário não foram informados")]
        public Guid IdUsuario { get; set; }
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O nome do pensador é obrigatório.")]
        public string Nome { get; set; }

    }
}
