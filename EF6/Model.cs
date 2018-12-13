using System;
using System.Data.Entity;

namespace EF6
{

    public partial class MirEntities : DbContext
    {
        public MirEntities()
            : base("name = mirDBConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<METERING>()
                .HasKey(c => new { c.IDOBJECT, c.IDTYPE_OBJECT, c.TIME_END, c.IDOBJECT_AGGREGATE, c.IDOBJECT_AVERAGE });
        }

        public virtual DbSet<METERING> METERINGS { get; set; }
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
