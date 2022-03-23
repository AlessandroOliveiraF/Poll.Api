using Microsoft.EntityFrameworkCore;
using Poll.Api.Domain;

namespace Poll.Api.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Enquete> Enquetes { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
    }
}
