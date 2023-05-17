using ErrorTranspose.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorTranspose.Data
{
    public class ErrorDbContext : DbContext
    {
        public ErrorDbContext(DbContextOptions<ErrorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Error> Errors { get; set; }
    }
}
