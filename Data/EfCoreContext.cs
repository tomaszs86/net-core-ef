using net_core_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace net_core_ef.Data
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {                                   
        }

        public DbSet<Task> Tasks { get; set; }
    }
}