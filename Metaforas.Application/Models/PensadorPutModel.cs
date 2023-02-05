using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class PensadorPutModel
    {
        [Required(ErrorMessage = "O identificador do pensador é obrigatório")]
        public Guid IdPensador { get; set; }
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O nome do pensador é obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o estado do registro.")]
        public bool Ativo { get; set; }

    }
}
