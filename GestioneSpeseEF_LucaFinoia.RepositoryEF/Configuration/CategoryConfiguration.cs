using GestioneSpeseEF_LucaFinoia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneSpeseEF_LucaFinoia.RepositoryEF
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(c=>c.Id);
            builder.Property(c=>c.Categoria).IsRequired();
        }
    }
}