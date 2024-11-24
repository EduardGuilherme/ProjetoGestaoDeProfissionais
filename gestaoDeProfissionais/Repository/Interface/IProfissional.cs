using gestaoDeProfissionais.Models;
using System.Linq.Expressions;

namespace gestaoDeProfissionais.Repository.Interface
{
    public interface IProfissional
    {
        Task<IEnumerable<Profissional>> GetAllAsync();
        Task<Profissional?> GetByIdAsync(int id);
        Task<Profissional> AddAsync(Profissional profissional);
        Task<Profissional> UpdateAsync(Profissional profissional);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

    }
}
