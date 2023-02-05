using Metaforas.Domain.Interfaces.Entity;

namespace Metaforas.Domain.Entities
{
    public class Pensador : IBaseEntity
    {
        public Guid IdPensador { get; set; }
        public Guid IdUsuario { get; set; }
        
        public string Nome { get; set; }
        
        public bool Ativo { get; set; }
        public Guid UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid? UsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public Guid? UsuarioInativacao { get; set; }
        public DateTime? DataInativacao { get; set; }

        public List<Frase> Frases { get; set; }
        public List<PensadorTime> PensadorTimes { get; set; }

    }
}
