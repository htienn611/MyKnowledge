namespace WebApi.repository
{
    using WebApi.data;
    using WebApi.model;
    using Microsoft.EntityFrameworkCore;

    public interface IMajorRepository
    {
        Task<IEnumerable<Major>> GetAllMajors();
        Task<Major?> GetMajor(int id);
    }

    public class MajorRepository(WebApiDbContext context) : IMajorRepository
    {
        private readonly WebApiDbContext _context = context;

        public async Task<IEnumerable<Major>> GetAllMajors()
        {
            try
            {
                var majors = await _context.Major.ToListAsync();
                return majors;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while retrieving the majors.", ex);
            }
        }

        public async Task<Major?> GetMajor(int id)
        {
            try
            {
                var major = await _context.Major.FindAsync(id);
                return major;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while retrieving the major.", ex);
            }
        }
    }
}