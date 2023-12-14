using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(p => p.CPF).IsRequired().HasMaxLength(14).IsUnicode(false);
            builder.Property(p => p.PhotoPath).HasMaxLength(255).IsUnicode(false);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CPF)
                .HasAnnotation("RegularExpression", @"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .HasAnnotation("RegularExpressionErrorMessage", "Formato de CPF inválido.");
        }
    }
}
