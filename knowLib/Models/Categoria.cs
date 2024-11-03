using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace knowLib.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Descrição:")]
        [Required(ErrorMessage = "A descrição da categoria é obrigatória.")]
        public string Descricao { get; set; }

        [DisplayName("Icone:")]
        public string Icone { get; set; }

        // Relacionamento com Ebooks e Artigos
        public ICollection<Ebook> Ebooks { get; set; }
        public ICollection<Artigo> Artigos { get; set; }
    }
}