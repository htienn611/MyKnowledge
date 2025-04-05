using Microsoft.EntityFrameworkCore;
using WebApi.model;

namespace WebApi.data
{
    public class WebApiDbContext(DbContextOptions<WebApiDbContext> options) : DbContext(options)
    {
        // Định nghĩa bảng trong database 
        public DbSet<Major> Major { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(m => m.Email); // Đặt khóa chính cho bảng User là Email
        }
    }
}
