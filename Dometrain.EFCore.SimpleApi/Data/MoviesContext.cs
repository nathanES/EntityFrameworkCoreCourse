using Dometrain.EFCore.SimpleApi.Data.EntityMapping;
using Dometrain.EFCore.SimpleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.SimpleApi.Data;

public class MoviesContext : DbContext
{
    public MoviesContext() { }
    
    public MoviesContext(DbContextOptions<MoviesContext> options)
        :base(options)
    { }
    
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Not proper logging
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
    }
}