using gestaoDeProfissionais.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestaoDeProfissionais.Data.Map
{
    public class ProfissinalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("Profissionais");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(p => p.Especialidade)
                .WithMany() 
                .HasForeignKey(p => p.EspecialidadeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
