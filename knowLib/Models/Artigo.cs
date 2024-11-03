using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace knowLib.Models
{
    public class Artigo
    {
        [Key]
        [Column("id_Artigo")]
        public int Id { get; set; }

        [DisplayName("Titulo:")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [DisplayName("Resumo:")]
        [Required(ErrorMessage = "O resumo é obrigatório.")]
        public string Resumo { get; set; }

        [DisplayName("DOI:")]
        [Required(ErrorMessage = "O DOI é obrigatório.")]
        public string DOI { get; set; }

        [DisplayName("Arquivo:")]
        [Required(ErrorMessage = "O arquivo é obrigatório.")]
        public string Arquivo { get; set; }

        [DisplayName("Data Publicação:")]
        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Revista:")]
        [Required(ErrorMessage = "O nome da revista é obrigatório.")]
        public string Revista { get; set; }

        [DisplayName("Volume:")]
        public int Volume { get; set; }

        [DisplayName("Edição:")]
        public int Edicao { get; set; }

        [DisplayName("Autores:")]
        // Relacionamento com Autor (um artigo pode ter vários autores)
        public ICollection<Autor> Autores { get; set; }

        [DisplayName("Categorias:")]
        // Relacionamento com Categoria (um artigo pode pertencer a várias categorias)
        public ICollection<Categoria> Categorias { get; set; }

        [DisplayName("Avaliações:")]
        // Relacionamento com Avaliacoes
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
