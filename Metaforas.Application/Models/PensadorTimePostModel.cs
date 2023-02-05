using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class PensadorTimePostModel
    {
        [Required(ErrorMessage = "O Id do Pensador é obrigatório.")]
        public Guid IdPensador { get; set; }
        [Required(ErrorMessage = "O Id do Time é obrigatório.")]
        public Guid IdTime { get; set; }
    }
}
