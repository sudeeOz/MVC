using Microsoft.EntityFrameworkCore;
using TestOBS.Models;
using System.Linq;

namespace TestOBS.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }  

        internal static bool ReferenceEquals(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
