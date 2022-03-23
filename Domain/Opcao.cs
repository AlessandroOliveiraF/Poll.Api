using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poll.Api.Domain
{
    public class Opcao : BaseEntity
    {
        public Opcao()
        {

        }

        public Opcao(string nome, int enqueteId)
        {
            ValidaOpcao(nome, enqueteId);
            Nome = nome;
            EnqueteId = enqueteId;
        }

        [Required]
        public string Nome { get; private set; }

        [ForeignKey("EnqueteFK")]
        public int EnqueteId { get; private set; }

        public virtual Enquete Enquete { get; private set; }

        private static void ValidaOpcao(string nome, int enqueteId)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("A opcao é inválida");

            if (!(enqueteId > 0))
                throw new InvalidOperationException("A enquete é inválida");
        }
    }
}
