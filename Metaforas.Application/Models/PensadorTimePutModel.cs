using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class PensadorTimePutModel
    {
        [Required(ErrorMessage = "O Id do Pensador é obrigatório.")]
        public Guid IdPensadorTime { get; set; }
        [Required(ErrorMessage = "O Estado é obrigatório")]
        public bool Ativo { get; set; }
    }
}
