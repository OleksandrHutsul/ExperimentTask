using ExperimentTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTask.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ExperimentResult> ExperimentResults { get; set; }
    }
}
