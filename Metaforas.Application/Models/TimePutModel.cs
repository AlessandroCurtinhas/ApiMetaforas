using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class TimePutModel
    {
        [Required(ErrorMessage = "O identificador do time é obrigatório")]
        public Guid IdTime { get; set; }
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O nome do time é obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o estado do registro.")]
        public bool Ativo { get; set; }
    }
}
