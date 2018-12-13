using Microsoft.EntityFrameworkCore;
using System;


namespace NetCore
{
    public class MyContext : DbContext
    {
        public DbSet<METERING> METERINGs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=CHUGGUN\SQLEXPRESS;Initial Catalog=mir;Persist Security Info=True;User ID=cl;Password=cl");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<METERING>()
                .HasKey(c => new { c.IDOBJECT, c.IDTYPE_OBJECT, c.TIME_END, c.IDOBJECT_AGGREGATE, c.IDOBJECT_AVERAGE });
        }
    }

    public partial class METERING
    {
        public int IDOBJECT { get; set; }
        public int IDTYPE_OBJECT { get; set; }
        public DateTime TIME_BEGIN { get; set; }
        public DateTime TIME_END { get; set; }
        public int IDOBJECT_AGGREGATE { get; set; }
        public int IDOBJECT_AVERAGE { get; set; }
        public int? STATUS { get; set; }
        public double VALUE_METERING { get; set; }
        public DateTime TIME_INSERT { get; set; }
    }
}
