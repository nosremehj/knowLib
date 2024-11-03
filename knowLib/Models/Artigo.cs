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
        [Required(ErrorMessage = "O t�tulo � obrigat�rio.")]
        public string Titulo { get; set; }

        [DisplayName("Resumo:")]
        [Required(ErrorMessage = "O resumo � obrigat�rio.")]
        public string Resumo { get; set; }

        [DisplayName("DOI:")]
        [Required(ErrorMessage = "O DOI � obrigat�rio.")]
        public string DOI { get; set; }

        [DisplayName("Arquivo:")]
        [Required(ErrorMessage = "O arquivo � obrigat�rio.")]
        public string Arquivo { get; set; }

        [DisplayName("Data Publica��o:")]
        [Required(ErrorMessage = "A data de publica��o � obrigat�ria.")]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Revista:")]
        [Required(ErrorMessage = "O nome da revista � obrigat�rio.")]
        public string Revista { get; set; }

        [DisplayName("Volume:")]
        public int Volume { get; set; }

        [DisplayName("Edi��o:")]
        public int Edicao { get; set; }

        [DisplayName("Autores:")]
        // Relacionamento com Autor (um artigo pode ter v�rios autores)
        public ICollection<Autor> Autores { get; set; }

        [DisplayName("Categorias:")]
        // Relacionamento com Categoria (um artigo pode pertencer a v�rias categorias)
        public ICollection<Categoria> Categorias { get; set; }

        [DisplayName("Avalia��es:")]
        // Relacionamento com Avaliacoes
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
