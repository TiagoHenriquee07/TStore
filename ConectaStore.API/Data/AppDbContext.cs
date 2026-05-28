using ConectaStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaStore.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedCategoria(modelBuilder);
        SeedProduto(modelBuilder);
    }

    private static void SeedCategoria(ModelBuilder builder)
    {
        List<Categoria> categorias = [
            new() { Id = 1, Nome = "Smartphones" },
            new() { Id = 2, Nome = "Notebooks" },
            new() { Id = 3, Nome = "Smartwatches" },
            new() { Id = 4, Nome = "Fones de Ouvido "}
        ];
        builder.Entity<Categoria>().HasData(categorias);
    }
    
    private static void SeedProduto(ModelBuilder builder)
    {
        List<Produto> produtos = [
            new () {
                Id = 1,
                CategoriaId = 1,   // Smartphone
                Nome = "iPhone 17 Pro",
                Descricao = "Apple não faço ideia do que escrever aqui, eu só tive android a vida inteira",
                ValorCusto = 1000m,
                ValorVenda = 10000.50m,
                Qtde = 0,
                Destaque = true,
                Foto = null,
            }
        ];
        builder.Entity<Produto>().HasData(produtos);
    }
}
