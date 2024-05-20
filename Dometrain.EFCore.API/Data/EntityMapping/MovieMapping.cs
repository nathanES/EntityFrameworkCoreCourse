using Dometrain.EFCore.API.Data.ValueConverters;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Pictures")
            .HasQueryFilter(movie => movie.ReleaseDate >= new DateTime(1990,1,1))
            .HasKey(movie => movie.Id);
    
        builder.Property(movie => movie.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(movie => movie.ReleaseDate)
            .HasColumnType("char(8)")
            .HasConversion(new DateTimeToChar8Converter());
    
        builder.Property(movie => movie.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");
        
        builder.Property(movie => movie.AgeRating)
            .HasColumnType("varchar(32)")
            .HasConversion<string>();

        
        // builder.ComplexProperty(movie => movie.Director);//It add a column by propertie of movie.Director in the database
        
        //It's a separate entity and can be had to another Table
        builder.OwnsOne(movie => movie.Director)
            .ToTable("Movie_Directors");
        
        builder.OwnsMany(movie => movie.Actors)
            .ToTable("Movie_Actors");
        
        builder.HasOne(movie => movie.Genre)
            .WithMany(genre => genre.Movies)
            .HasPrincipalKey(genre => genre.Id)
            .HasForeignKey(movie => movie.MainGenreId);
    }
}