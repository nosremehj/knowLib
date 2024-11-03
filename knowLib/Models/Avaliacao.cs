using knowLib.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace knowLib.Models
{

    public class Avaliacao
    {
        public int Id { get; set; }

        [DisplayName("Coment�rio:")]
        [Required(ErrorMessage = "O coment�rio � obrigat�rio.")]
        public string Comentario { get; set; }

        [DisplayName("Nota:")]
        [Required(ErrorMessage = "A nota � obrigat�ria.")]
        [Range(1, 5, ErrorMessage = "A nota deve estar entre 1 e 5.")]
        public int Nota { get; set; }

        [DisplayName("Data de avalia��o:")]
        [Required(ErrorMessage = "A data da avalia��o � obrigat�ria.")]
        public DateTime DataAvaliacao { get; set; }

        // Relacionamento com Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relacionamento com Ebook ou Artigo (um deles deve ser preenchido)
        public int? EbookId { get; set; }
        public Ebook Ebook { get; set; }

        public int? ArtigoId { get; set; }
        public Artigo Artigo { get; set; }
    }
}