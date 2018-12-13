using Comparison;
using System;

namespace EF6
{
    public class EF6Provider : Provider<METERING>
    {
        public override string Name => "EF6";

        public EF6Provider(Metering[] meterings) : base(meterings)
        {
        }

        protected override void AddSingle(METERING item)
        {
            using (var context = new MirEntities())
            {
                context.METERINGS.Add(item);
                context.SaveChanges();
            }
        }

        protected override void AddMultiple(METERING[] dataItems)
        {
            using (var context = new MirEntities())
            {
                context.METERINGS.AddRange(dataItems);
                context.SaveChanges();
            }
        }

        public override void ClearSource()
        {
            using (var context = new MirEntities())
            {
                context.METERINGS.RemoveRange(context.METERINGS);
                context.SaveChanges();
            }
        }

        protected override METERING[] CreateDataItems(Metering[] meterings)
        {
            return Array.ConvertAll(meterings,
                p => new METERING()
                {
                    IDOBJECT = p.IDOBJECT,
                    IDOBJECT_AVERAGE = p.IDOBJECT_AVERAGE,
                    IDTYPE_OBJECT = p.IDTYPE_OBJECT,
                    STATUS = p.STATUS,
                    TIME_BEGIN = p.TIME_BEGIN,
                    TIME_END = p.TIME_END,
                    VALUE_METERING = p.VALUE_METERING
                });
        }
    }
}
