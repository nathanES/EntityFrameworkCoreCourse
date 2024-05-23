using Dometrain.EFCoreTenants.Databases.Data.EntityMapping;
using Dometrain.EFCoreTenants.Databases.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCoreTenants.Databases.Data;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options)
        :base(options)
    { }
    
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
    }
}