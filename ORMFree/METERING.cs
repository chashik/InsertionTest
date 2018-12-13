using System;

namespace ORMFree
{
    public class METERING
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
