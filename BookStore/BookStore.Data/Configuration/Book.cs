using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStore.Data.Domain;

namespace BookStore.Data.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Title).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Author).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.PageCount).IsRequired(true);
        builder.Property(x => x.PublishDate).IsRequired(true);
        builder.Property(x => x.Price).IsRequired(true).HasPrecision(6, 2);
    }
}