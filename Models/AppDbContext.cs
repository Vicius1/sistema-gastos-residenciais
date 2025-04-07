using Microsoft.EntityFrameworkCore;

namespace gastosResidenciais.Models
{
    // Classe que representa o banco de dados em memória usando Entity Framework Core
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
