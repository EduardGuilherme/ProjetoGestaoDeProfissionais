using gestaoDeProfissionais.Data.Map;
using gestaoDeProfissionais.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace gestaoDeProfissionais.Data
{
    public class GestaoDeProfissionaisDBContext:DbContext
    {
        public GestaoDeProfissionaisDBContext(DbContextOptions<GestaoDeProfissionaisDBContext> options) : base(options) { }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            modelBuilder.ApplyConfiguration(new ProfissinalMap());
            modelBuilder.ApplyConfiguration(new EspecialidadeMap());

            modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade { Id = 1, Nome = "Cardiologia", TipoDocumento = "CRM" },
                new Especialidade { Id = 2, Nome = "Nutricionista Clínico", TipoDocumento = "CRN" }
            );
        }
    }
}
