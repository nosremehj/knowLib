using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace knowLib.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Instituição:")]
        [Required(ErrorMessage = "A instituição é obrigatória.")]
        public string Instituicao { get; set; }

        [DisplayName("Email para Contato:")]
        [Required(ErrorMessage = "O e-mail de contato é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailContato { get; set; }

        [DisplayName("Bio:")]
        public string Bio { get; set; }

        [DisplayName("Orc:")]
        public string OrcId { get; set; }

        [DisplayName("Artigos:")]
        // Relacionamento com Artigos (um autor pode escrever vários artigos)
        public ICollection<Artigo> Artigos { get; set; }
    }
}