using GestioneSpeseEF_LucaFinoia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneSpeseEF_LucaFinoia.RepositoryEF
{
    internal class SpeseConfiguration : IEntityTypeConfiguration<Spese>
    {
        public void Configure(EntityTypeBuilder<Spese> builder)
        {
            builder.ToTable("Spese");
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Categoria).WithMany(c=>c.SpeseList).HasForeignKey(s => s.CategoryId);
        }
    }
}