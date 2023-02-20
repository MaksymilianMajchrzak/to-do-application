global using Microsoft.EntityFrameworkCore;

namespace ToDoBackend.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server = .\\SQLExpress; Database = taskdb; Trusted_Connection = true;TrustServerCertificate=true;");
        }
        public DbSet<Assignment> Tasks { get; set; }
    }
}
