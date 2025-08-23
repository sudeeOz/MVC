using Microsoft.EntityFrameworkCore;
using TestOBS.Models;

namespace TestOBS.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        internal static bool ReferenceEquals(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
