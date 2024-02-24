using Microsoft.EntityFrameworkCore;
using PdvGrow.api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    // DbSets


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venda>()
            .Property(v => v.ProdutoIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
            );
    }
}
