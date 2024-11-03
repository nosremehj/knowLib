using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace knowLib.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        public string Nome { get; set; }

        [DisplayName("Institui��o:")]
        [Required(ErrorMessage = "A institui��o � obrigat�ria.")]
        public string Instituicao { get; set; }

        [DisplayName("Email para Contato:")]
        [Required(ErrorMessage = "O e-mail de contato � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inv�lido.")]
        public string EmailContato { get; set; }

        [DisplayName("Bio:")]
        public string Bio { get; set; }

        [DisplayName("Orc:")]
        public string OrcId { get; set; }

        [DisplayName("Artigos:")]
        // Relacionamento com Artigos (um autor pode escrever v�rios artigos)
        public ICollection<Artigo> Artigos { get; set; }
    }
}