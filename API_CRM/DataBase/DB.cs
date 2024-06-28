using Microsoft.EntityFrameworkCore;
using Models;

namespace API_CRM.DataBase
{
    public class DB : DbContext
    {
        public DB()=>Database.EnsureCreated();
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Api_DB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Company>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<History>().HasKey(x => x.Id);
            modelBuilder.Entity<History>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Transaction>().HasKey(x => x.Id);
            modelBuilder.Entity<Transaction>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<WorkTask>().HasKey(x => x.Id);
            modelBuilder.Entity<WorkTask>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
