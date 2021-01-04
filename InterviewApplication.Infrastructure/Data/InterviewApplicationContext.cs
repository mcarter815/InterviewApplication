using InterviewApplication.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewApplication.Infrastructure.Data
{
    public class InterviewApplicationContext : DbContext
    {
        public InterviewApplicationContext(DbContextOptions<InterviewApplicationContext> options) : base(options){}

        public DbSet<Dashboard> Dashboard { get; set; }
    }
}
