using Microsoft.EntityFrameworkCore;


namespace SeparatorBack.Models
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
