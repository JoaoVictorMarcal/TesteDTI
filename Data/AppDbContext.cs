using Microsoft.EntityFrameworkCore;
using testeDTI.Models;

namespace testeDTI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Lead> BancoLeads { get; set; }
    }

}
