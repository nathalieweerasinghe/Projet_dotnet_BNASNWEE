using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BNASNWEE.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        public MyAirportContext(DbContextOptions<MyAirportContext> option)
            : base(option)
        {
        }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Bagage> Bagages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
        }
    }


}
