using Microsoft.EntityFrameworkCore;

namespace Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model
{
    public class Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Vs2015WinFormsEfcSqliteCodeFirst20170304Example.sqlite");
        }
    }
}
