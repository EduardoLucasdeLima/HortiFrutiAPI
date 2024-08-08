using HortiFrutiAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HortiFrutiAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Fruta>? Frutas { get; set; }
}
