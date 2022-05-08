using APIStandBy.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStandBy.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<tb_clientes> tb_clientes { get; set; }
    }
}
