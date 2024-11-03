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
        [Required(ErrorMessage = "O t�tulo � obrigat�rio.")]
        public string Titulo { get; set; }

        [DisplayName("Resumo:")]
        [Required(ErrorMessage = "O resumo � obrigat�rio.")]
        public string Resumo { get; set; }

        [DisplayName("ISBN:")]
        [Required(ErrorMessage = "O ISBN � obrigat�rio.")]
        public string ISBN { get; set; }

        [DisplayName("Arquivo:")]
        [Required(ErrorMessage = "O arquivo � obrigat�rio.")]
        public string Arquivo { get; set; }

        [DisplayName("Data de Publica��o:")]
        [Required(ErrorMessage = "A data de publica��o � obrigat�ria.")]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Quantidade de p�ginas:")]
        public int NumeroPaginas { get; set; }

        [DisplayName("Qual o Idioma?")]
        public string Idioma { get; set; }

        // Relacionamento com Categoria
        public ICollection<Categoria> Categorias { get; set; }

        // Relacionamento com Avaliacoes
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}