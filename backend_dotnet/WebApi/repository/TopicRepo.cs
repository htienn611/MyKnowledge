using Microsoft.EntityFrameworkCore;
using WebApi.data;
using WebApi.model;

namespace WebApi.repository
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopics();
        Task<Topic?> GetTopic(int id);
    }

    public class TopicRepository(WebApiDbContext context) : ITopicRepository
    {
        private readonly WebApiDbContext _context = context;

        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            return await _context.Topic.ToListAsync();
        }

        public async Task<Topic?> GetTopic(int id)
        {
            return await _context.Topic.FindAsync(id);
        }
    }
}
