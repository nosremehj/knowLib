using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace knowLib.Models
{
    public class Ebook
    {
        [Key]
        [Column("id_ebook")]
        public int Id { get; set; }

        [DisplayName("Titulo:")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [DisplayName("Resumo:")]
        [Required(ErrorMessage = "O resumo é obrigatório.")]
        public string Resumo { get; set; }

        [DisplayName("ISBN:")]
        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        public string ISBN { get; set; }

        [DisplayName("Arquivo:")]
        [Required(ErrorMessage = "O arquivo é obrigatório.")]
        public string Arquivo { get; set; }

        [DisplayName("Data de Publicação:")]
        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Quantidade de páginas:")]
        public int NumeroPaginas { get; set; }

        [DisplayName("Qual o Idioma?")]
        public string Idioma { get; set; }

        // Relacionamento com Categoria
        public ICollection<Categoria> Categorias { get; set; }

        // Relacionamento com Avaliacoes
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}