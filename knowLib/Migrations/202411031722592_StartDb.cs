namespace knowLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigoes",
                c => new
                    {
                        id_Artigo = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Resumo = c.String(nullable: false),
                        DOI = c.String(nullable: false),
                        Arquivo = c.String(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        Revista = c.String(nullable: false),
                        Volume = c.Int(nullable: false),
                        Edicao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Artigo);
            
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Instituicao = c.String(nullable: false),
                        EmailContato = c.String(nullable: false),
                        Bio = c.String(),
                        OrcId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Avaliacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comentario = c.String(nullable: false),
                        Nota = c.Int(nullable: false),
                        DataAvaliacao = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        EbookId = c.Int(),
                        ArtigoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artigoes", t => t.ArtigoId)
                .ForeignKey("dbo.Ebooks", t => t.EbookId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.EbookId)
                .Index(t => t.ArtigoId);
            
            CreateTable(
                "dbo.Ebooks",
                c => new
                    {
                        id_ebook = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Resumo = c.String(nullable: false),
                        ISBN = c.String(nullable: false),
                        Arquivo = c.String(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        NumeroPaginas = c.Int(nullable: false),
                        Idioma = c.String(),
                    })
                .PrimaryKey(t => t.id_ebook);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Icone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false),
                        senha = c.String(nullable: false),
                        nome = c.String(nullable: false),
                        profile = c.String(nullable: false),
                        ConfirmationToken = c.String(),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_user);
            
            CreateTable(
                "dbo.ArtigoAutor",
                c => new
                    {
                        ArtigoId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtigoId, t.AutorId })
                .ForeignKey("dbo.Artigoes", t => t.ArtigoId, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.ArtigoId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.EbookCategoria",
                c => new
                    {
                        EbookId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EbookId, t.CategoriaId })
                .ForeignKey("dbo.Ebooks", t => t.EbookId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.EbookId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ArtigoCategoria",
                c => new
                    {
                        ArtigoId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtigoId, t.CategoriaId })
                .ForeignKey("dbo.Artigoes", t => t.ArtigoId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.ArtigoId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtigoCategoria", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.ArtigoCategoria", "ArtigoId", "dbo.Artigoes");
            DropForeignKey("dbo.Avaliacaos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.EbookCategoria", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.EbookCategoria", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.Avaliacaos", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.Avaliacaos", "ArtigoId", "dbo.Artigoes");
            DropForeignKey("dbo.ArtigoAutor", "AutorId", "dbo.Autors");
            DropForeignKey("dbo.ArtigoAutor", "ArtigoId", "dbo.Artigoes");
            DropIndex("dbo.ArtigoCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.ArtigoCategoria", new[] { "ArtigoId" });
            DropIndex("dbo.EbookCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.EbookCategoria", new[] { "EbookId" });
            DropIndex("dbo.ArtigoAutor", new[] { "AutorId" });
            DropIndex("dbo.ArtigoAutor", new[] { "ArtigoId" });
            DropIndex("dbo.Avaliacaos", new[] { "ArtigoId" });
            DropIndex("dbo.Avaliacaos", new[] { "EbookId" });
            DropIndex("dbo.Avaliacaos", new[] { "UsuarioId" });
            DropTable("dbo.ArtigoCategoria");
            DropTable("dbo.EbookCategoria");
            DropTable("dbo.ArtigoAutor");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Ebooks");
            DropTable("dbo.Avaliacaos");
            DropTable("dbo.Autors");
            DropTable("dbo.Artigoes");
        }
    }
}
