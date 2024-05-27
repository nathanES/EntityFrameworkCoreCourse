using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class ActorMapping : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        //With HasMany and WithMany alone it will work fine
        builder.HasMany(actor => actor.Movies)
            .WithMany(movie => movie.Actors)
            .UsingEntity("Movie_Actor",
                left => left.HasOne(typeof(Movie))
                    .WithMany()
                    .HasForeignKey("MovieId")
                    .HasPrincipalKey(nameof(Movie.Id))
                    .HasConstraintName("FK_MovieActor_Movie")
                    .OnDelete(DeleteBehavior.Cascade),
                right => right.HasOne(typeof(Actor))
                    .WithMany()
                    .HasForeignKey("ActorId")
                    .HasPrincipalKey(nameof(Actor.Id))
                    .HasConstraintName("FK_MovieActor_Actor")
                    .OnDelete(DeleteBehavior.Cascade),
                linkBuilder => linkBuilder.HasKey("MovieId", "ActorId"));
    }
}