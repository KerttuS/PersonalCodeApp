using Microsoft.EntityFrameworkCore;

namespace PersonalCodeApi.Data
{
    public class DataContext : DbContext
    {  
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<PersonalCode> PersonalCodes { get; set; }
    }
}
