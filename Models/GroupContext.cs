using Microsoft.EntityFrameworkCore;


namespace SeparatorBack.Models
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
