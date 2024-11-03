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
        [Required(ErrorMessage = "O nome da categoria � obrigat�rio.")]
        public string Nome { get; set; }

        [DisplayName("Descri��o:")]
        [Required(ErrorMessage = "A descri��o da categoria � obrigat�ria.")]
        public string Descricao { get; set; }

        [DisplayName("Icone:")]
        public string Icone { get; set; }

        // Relacionamento com Ebooks e Artigos
        public ICollection<Ebook> Ebooks { get; set; }
        public ICollection<Artigo> Artigos { get; set; }
    }
}