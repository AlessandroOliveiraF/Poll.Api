using System.ComponentModel.DataAnnotations;

namespace Poll.Api.Domain
{
    public class Enquete : BaseEntity
    {
        public Enquete()
        {

        }

        public Enquete(string titulo, string descricao)
        {
            ValidaEnquete(titulo, descricao);
            Titulo = titulo;
            Descricao = descricao;
        }

        [Required]
        public string Titulo { get; private set; }

        [Required]
        public string Descricao { get; private set; }

        public virtual List<Opcao> Opcoes { get; set; } = new List<Opcao>();

        private static void ValidaEnquete(string titulo, string descricao)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new InvalidOperationException("O titulo é inválido");

            if (string.IsNullOrEmpty(descricao))
                throw new InvalidOperationException("A descricao é inválida");
        }
    }
}