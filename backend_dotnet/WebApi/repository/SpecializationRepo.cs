using Microsoft.EntityFrameworkCore;
using WebApi.data;
using WebApi.model;

namespace WebApi.repository
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetAllSpecializations();
        Task<Specialization?> GetSpecialization(int id);
    }
    public class SpecializationRepository(WebApiDbContext context) : ISpecializationRepository
    {
        private readonly WebApiDbContext _context = context;

        public async Task<IEnumerable<Specialization>> GetAllSpecializations()
        {
            return await _context.Specialization.ToListAsync();
        }

        public async Task<Specialization?> GetSpecialization(int id)
        {
            return await _context.Specialization.FindAsync(id);
        }
    }
}
