using CelebrityAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CelebrityAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Celebrity> Celebrity { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAdmin> UserAdmin { get; set; }
    }
}
