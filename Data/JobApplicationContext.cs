using Microsoft.EntityFrameworkCore;

namespace JobApplication.Data
{
    public class JobApplicationContext : DbContext
    {
        private readonly IConfiguration tableConf;
        public JobApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Candidate> Candidate { get; set; }
    }
}
