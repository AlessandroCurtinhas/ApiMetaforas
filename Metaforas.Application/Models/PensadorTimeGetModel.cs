
namespace Metaforas.Application.Models
{
    public class PensadorTimeGetModel
    {
        public Guid IdPensadorTime { get; set; }

        public Guid IdPensador { get; set; }
        public Guid IdTime { get; set; }

        public bool Ativo { get; set; }
        public Guid UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid? UsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public Guid? UsuarioInativacao { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}
