using Microsoft.EntityFrameworkCore;
using PersonalCodeApi;

namespace PersonalCodeApi.Data
{
    public class IDataContext : DbContext
    {  
        public IDataContext(DbContextOptions<IDataContext> options) : base(options) { }

        public DbSet<PersonalCode> PersonalCode { get; set; }
    }
}
