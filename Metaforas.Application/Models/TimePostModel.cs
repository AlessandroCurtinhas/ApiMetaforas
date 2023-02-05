using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class TimePostModel
    {
        [Required(ErrorMessage = "O nome do time é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        public string Nome { get; set; }

    }
}
