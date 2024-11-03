namespace knowLib.Data
{
    using knowLib.Models;
using System.Data.Entity;

public class AddDbContext : DbContext
{
    public AddDbContext() : base("AppDbContext") // Defina sua string de conexão aqui
    {
    }

    public DbSet<Artigo> Artigos { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ebook> Ebooks { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            // Configurar relacionamento muitos para muitos entre Artigo e Autor
            modelBuilder.Entity<Artigo>()
                .HasMany(a => a.Autores)
                .WithMany(au => au.Artigos)
                .Map(m =>
                {
                    m.ToTable("ArtigoAutor");
                    m.MapLeftKey("ArtigoId");
                    m.MapRightKey("AutorId");
                });

            // Configurar relacionamento muitos para muitos entre Artigo e Categoria
            modelBuilder.Entity<Artigo>()
                .HasMany(a => a.Categorias)
                .WithMany(c => c.Artigos)
                .Map(m =>
                {
                    m.ToTable("ArtigoCategoria");
                    m.MapLeftKey("ArtigoId");
                    m.MapRightKey("CategoriaId");
                });

            // Configurar relacionamento muitos para muitos entre Ebook e Categoria
            modelBuilder.Entity<Ebook>()
                .HasMany(e => e.Categorias)
                .WithMany(c => c.Ebooks)
                .Map(m =>
                {
                    m.ToTable("EbookCategoria");
                    m.MapLeftKey("EbookId");
                    m.MapRightKey("CategoriaId");
                });

            base.OnModelCreating(modelBuilder);
        }
}
}