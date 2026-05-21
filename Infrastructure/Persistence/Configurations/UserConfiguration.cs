using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.UserName)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.HasIndex(user => user.UserName)
                .IsUnique();

        builder.Property(user => user.Email)
                .IsRequired(true)
                .HasMaxLength(100);

        builder.HasIndex(user => user.Email)
                .IsUnique();

        builder.Property(user => user.Bio)
                .HasMaxLength(100);

        builder.HasMany(user => user.Posts)
                .WithOne(post => post.User)
                .HasForeignKey(post => post.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
        builder.HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
