using Comparison;
using System;

namespace ConsoleApp
{
    public class MyData
    {
        public MyData(int amount)
        {
            Meterings = new Metering[amount];
            var tbegin = DateTime.Now;
            var tend = tbegin.AddDays(1);
            var meter = 5E-1;
            for (var i = 0; i < amount; i++)
                Meterings[i] = new Metering()
                {
                    IDOBJECT = i,
                    IDOBJECT_AVERAGE = i,
                    IDTYPE_OBJECT = i,
                    STATUS = i,
                    TIME_BEGIN = tbegin,
                    TIME_END = tend,
                    VALUE_METERING = meter
                };
        }

        public Metering[] Meterings { get; }
    }
}
