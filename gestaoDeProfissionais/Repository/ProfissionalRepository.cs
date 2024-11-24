using gestaoDeProfissionais.Data;
using gestaoDeProfissionais.Models;
using gestaoDeProfissionais.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace gestaoDeProfissionais.Repository
{
    public class ProfissionalRepository : IProfissional
    {
        private readonly GestaoDeProfissionaisDBContext context;

        public ProfissionalRepository(GestaoDeProfissionaisDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Profissional>> GetAllAsync()
        {
            return await context.Profissionais.Include(p => p.Especialidade).ToListAsync();
        }

        public async Task<Profissional?> GetByIdAsync(int id)
        {
            return await context.Profissionais.Include(p => p.Especialidade).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Profissional> AddAsync(Profissional profissional)
        {
            var result = await context.Profissionais.AddAsync(profissional);
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var profissional = await context.Profissionais.FindAsync(id);
            if (profissional != null)
            {
                context.Profissionais.Remove(profissional);
            }
        }
        public Task<Profissional> UpdateAsync(Profissional profissional)
        {
            context.Profissionais.Update(profissional);
            return Task.FromResult(profissional);
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
