using Microsoft.EntityFrameworkCore;

namespace TestEf11
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<ParentEntity> Parents { get; set; }

        public virtual DbSet<ChildEntity> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestEf11;Trusted_Connection=True;");
        }
    }
}
